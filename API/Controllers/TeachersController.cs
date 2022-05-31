using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class TeachersController : BaseApiController
    {
        private readonly ITeacherRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        public TeachersController(ITeacherRepository userRepository,IMapper mapper,IPhotoService photoService)
        {
            _photoService = photoService;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetTeachers()
        {
            var teachers= await _userRepository.GetMemberTeachersAsync();
            return Ok(teachers);    
        }

        [HttpGet("{username}",Name ="GetTeacher")]
        public async Task<ActionResult<TeacherDto>> GetUser(string username)
        {
            var teacherByUsername= await _userRepository.GetMemberTeacherByUsernameAsync(username);
            var teacherByName= await _userRepository.GetMemberTeacherByNameAsync(username);
            var teacher= (teacherByUsername!=null)? teacherByUsername: teacherByName;
            return teacher;    
        }

        
        [HttpPut]
        public async Task<ActionResult> UpdateTeacher(TeacherUpdateDto teacherUpdateDto){
          //  var username= User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
          var username= teacherUpdateDto.Username;
            var teacher= await _userRepository.GetTeacherByUsernameAsync(username);
            _mapper.Map(teacherUpdateDto,teacher);
            _userRepository.UpdateTeacher(teacher);
            if(await _userRepository.SaveAllChangesAsync()) return NoContent();
            return BadRequest("Failed to update teacher information!");  
        }
        [HttpPost("add-photo")]
        public async Task<ActionResult<TeacherPhotoDto>> AddPhoto(IFormFile file){
            var username= User.GetUsername();
            var user = await _userRepository.GetTeacherByUsernameAsync(username);
            var result = await _photoService.AddPhotoAsync(file);
            if(result.Error!=null) return BadRequest(result.Error.Message);
            var photo = new TeacherPhoto{
                Url=result.SecureUrl.AbsoluteUri,
                PublicId= result.PublicId
            };

            if(user.Photos.Count==0){
                photo.IsMain=true;
            }
            user.Photos.Add(photo);
            if(await _userRepository.SaveAllChangesAsync()){
              
                return CreatedAtRoute("GetTeacher",new{username=user.UserName},_mapper.Map<TeacherPhotoDto>(photo));
            } 

            return BadRequest("Problem occured while adding a photo!");
        }

        [HttpPut("set-main-photo/{photoid}")]
        public async Task<ActionResult> SetMainPhoto(int photoId)
        {
            var username= User.GetUsername();
            var user = await _userRepository.GetTeacherByUsernameAsync(username);
          
            var photo= user.Photos.FirstOrDefault(x=>x.Id==photoId);
            if(photo.IsMain) return BadRequest("This is already a main photo");
            var currentMain= user.Photos.FirstOrDefault(x=>x.IsMain);
            if(currentMain!=null) currentMain.IsMain=false;
            photo.IsMain=true;

            if(await _userRepository.SaveAllChangesAsync()) return NoContent();
            return  BadRequest("Failed to set main photo");
        }  
            
        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId){
            var username= User.GetUsername();
            var teacher = await _userRepository.GetTeacherByUsernameAsync(username);
          
            var photo= teacher.Photos.FirstOrDefault(x=>x.Id==photoId);
            if(photo==null) return NotFound();
            if(photo.IsMain) return BadRequest("You cannot delete your main photo"); 
            if(photo.PublicId!=null){
                var result= await _photoService.DeletePhotoAsync(photo.PublicId);
                if(result.Error!=null) return BadRequest(result.Error.Message);

            }
            teacher.Photos.Remove(photo);
            if(await _userRepository.SaveAllChangesAsync()) return Ok();

            return BadRequest("Failed to delete a photo!");
        }
     
    }
}