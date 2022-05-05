using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.DTOs.Course;
using API.DTOs.Parameters;
using API.Entities.CourseDetails;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class CoursesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public CoursesController(DataContext context, IMapper mapper,IFileService fileService)
        {
            _fileService = fileService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses(){
            var courses= await _context.Courses.ProjectTo<CourseDto>(_mapper.ConfigurationProvider).AsSingleQuery() //** Might cause issue
                .ToListAsync();
            return Ok(courses);
        }

        [HttpGet("{name}",Name ="GetCourse")]
        public async Task<ActionResult<CourseDto>> GetCourse(string name)
        {
            var courseByName = await _context.Courses.ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                .AsSingleQuery().SingleOrDefaultAsync(x=>x.NameOfCourse.ToLower()==name.ToLower());
            
            var courseByCourseCode = await _context.Courses.ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                .AsSingleQuery().SingleOrDefaultAsync(x=>x.CourseCode.ToLower()==name.ToLower());
            var course  = (courseByName!=null)?courseByName:courseByCourseCode;
            return Ok(course);    
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCourse(CourseUpdateDto courseUpdateDto){
          var courseCode= courseUpdateDto.CourseCode;
            var course= await _context.Courses.SingleOrDefaultAsync(x=>x.CourseCode.ToLower()== courseCode.ToLower());
            _mapper.Map(courseUpdateDto,course);
            _context.Entry(course).State=EntityState.Modified;

            if((await _context.SaveChangesAsync()>0)) return NoContent();
            return BadRequest("Failed to update course!");  
        }       

        
        [HttpPost("add-file")]
        public async Task<ActionResult<CourseUploadFileDto>> AddFile(string courseCode,IFormFile file){
            var course= await _context.Courses.Include(x=>x.Announcements).Include(x=>x.CourseFiles).AsSplitQuery()
                                            .SingleOrDefaultAsync(x=>x.CourseCode.ToLower()== courseCode.ToLower());
            
            var result = file.FileName.Contains(".pdf")? await _fileService.AddPDFFileAsync(file):
                                                         await _fileService.AddFileAsync(file);                
            
            if(result.Error!=null) return BadRequest(result.Error.Message);
            var uploadingFile = new CourseUploadFile{ 
                Url=result.SecureUrl.AbsoluteUri, 
                PublicId= result.PublicId,
                FileName= file.FileName  
            };
            course.CourseFiles?.Add(uploadingFile);
            if(await _context.SaveChangesAsync()>0){ 

                return CreatedAtRoute("GetCourse", new {name=course.CourseCode},
                                        _mapper.Map<CourseUploadFileDto>(uploadingFile));
            } 

            return BadRequest("Problem occured while adding a file!");
        }
        [HttpDelete("delete-file/{fileId}")]
        public async Task<ActionResult> DeleteFile(string courseCode,int fileId){
       
            var course= await _context.Courses.Include(x=>x.Announcements).Include(x=>x.CourseFiles).AsSplitQuery()
                                            .SingleOrDefaultAsync(x=>x.CourseCode.ToLower()== courseCode.ToLower());
           
            var file= course.CourseFiles.FirstOrDefault(x=>x.Id==fileId);
            if(file==null) return NotFound();
            if(file.PublicId!=null){
                var result= await _fileService.DeleteFileAsync(file.PublicId);
                if(result.Error!=null) return BadRequest(result.Error.Message);

            }
            course.CourseFiles.Remove(file);
            if(await _context.SaveChangesAsync()>0) return Ok();

            return BadRequest("Failed to delete a file!");
        }
        
        [HttpPut("set-outline-file/{fileId}")]
        public async Task<ActionResult> SetOutlineFile(string courseCode, int fileId)
        {
            var course= await _context.Courses.Include(x=>x.CourseFiles).AsSplitQuery()
                                .SingleOrDefaultAsync(x=>x.CourseCode.ToLower()== courseCode.ToLower());
           //this field is not working 
            var file= course.CourseFiles.FirstOrDefault(x=>x.Id==fileId);
            if(file.IsOutline) return BadRequest("This is already an outline file");
            var currentMain= course.CourseFiles.FirstOrDefault(x=>x.IsOutline);
            if(currentMain!=null) currentMain.IsOutline=false;
            file.IsOutline=true;

            if(await _context.SaveChangesAsync()>0) return NoContent();
            return  BadRequest("Failed to set outine file");
        }
        [HttpPost("add-video")]
        public async Task<ActionResult<LectureVideosDto>> AddVideo(AddVideoParams videoParams){
            var course= await _context.Courses.Include(x=>x.Announcements).Include(x=>x.CourseFiles).Include(x=>x.LectureVideos).AsSplitQuery()
                                            .SingleOrDefaultAsync(x=>x.CourseCode.ToLower()== videoParams.CourseCode.ToLower());
            
            var video = new LectureVideos{ 
                Url=videoParams.VideoUrl,
                NameOfVideo=videoParams.Name
            };
            course.LectureVideos.Add(video);
            if(await _context.SaveChangesAsync()>0){ 

                return CreatedAtRoute("GetCourse", new {name=course.CourseCode},
                                        _mapper.Map<LectureVideosDto>(video));
            } 

            return BadRequest("Problem occured while uploading video!");
        }
        [HttpPost("add-announcement")]
        public async Task<ActionResult<LectureVideosDto>> AddAnnouncemnet(UploadAnnouncementParams announcementParams){
            var course= await _context.Courses.Include(x=>x.Announcements).Include(x=>x.CourseFiles).Include(x=>x.LectureVideos).AsSplitQuery()
                                            .SingleOrDefaultAsync(x=>x.CourseCode.ToLower()== announcementParams.CourseCode.ToLower());
            
            var announcementText = new Announcements{ 
                Announcement=announcementParams.Announcement
            };
            course.Announcements.Add(announcementText);
            if(await _context.SaveChangesAsync()>0){ 

                return CreatedAtRoute("GetCourse", new {name=course.CourseCode},
                                        _mapper.Map<AnnouncementDto>(announcementText));
            } 
// now work on how to send object from the client request by createding dto or parameters classes
            return BadRequest("Problem occured while uploading announcement!");
        }

        [HttpPut("update-announcement")]
        public async Task<ActionResult> UpdateAnnouncement(AnnouncementUpdateDto announcementUpdate){

            var announcement= await _context.Announcements.SingleOrDefaultAsync(x=>x.Id==announcementUpdate.Id);
            _mapper.Map(announcementUpdate,announcement);
            _context.Entry(announcement).State=EntityState.Modified;

            if((await _context.SaveChangesAsync()>0)) return NoContent();
            return BadRequest("Failed to update annuncement!");  
        }       

        [HttpDelete("delete-video/{videoId}")]
        public async Task<ActionResult> DeleteVideo(string courseCode,int videoId){
       
            var course= await _context.Courses.Include(x=>x.Announcements).Include(x=>x.CourseFiles).Include(x=>x.LectureVideos).AsSplitQuery()
                                            .SingleOrDefaultAsync(x=>x.CourseCode.ToLower()== courseCode.ToLower());
           
            var video= course.LectureVideos.FirstOrDefault(x=>x.Id==videoId);
            if(video==null) return NotFound();
            
            course.LectureVideos.Remove(video);
            if(await _context.SaveChangesAsync()>0) return Ok();

            return BadRequest("Failed to delete a video!");
        }
        [HttpDelete("delete-announcement/{announcementId}")]
        public async Task<ActionResult> DeleteAnnouncement(string courseCode,int announcementId){
       
            var course= await _context.Courses.Include(x=>x.Announcements).Include(x=>x.CourseFiles).Include(x=>x.LectureVideos).AsSplitQuery()
                                            .SingleOrDefaultAsync(x=>x.CourseCode.ToLower()== courseCode.ToLower());
           
            var announcement= course.Announcements.FirstOrDefault(x=>x.Id==announcementId);
            if(announcement==null) return NotFound();
            
            course.Announcements.Remove(announcement);
            if(await _context.SaveChangesAsync()>0) return Ok();

            return BadRequest("Failed to delete a announcement!");
        }
}
}