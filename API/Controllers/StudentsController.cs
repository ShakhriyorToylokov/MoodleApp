using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class StudentsController : BaseApiController
    {
        private readonly IStudentRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        public StudentsController(IStudentRepository userRepository,IMapper mapper,IPhotoService photoService)
        {
            _photoService = photoService;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students= await _userRepository.GetMemberStudentsAsync();
            return Ok(students);    
        }

        [HttpGet("{username}",Name ="GetStudent")]
        public async Task<ActionResult<StudentDto>> GetStudent(string username)
        {
            var studentUsername  =  await _userRepository.GetMemberStudentAsync(username);
            var studentName  =  await _userRepository.GetMemberStudentByNameAsync(username);
            var student =  (studentUsername!=null)? studentUsername : studentName;
            return Ok(student);    
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStudent(StudentUpdateDto studentUpdateDto){
          //  var username= User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
          var username= studentUpdateDto.Username;
            var student= await _userRepository.GetStudentByUsernameAsync(username);
            _mapper.Map(studentUpdateDto,student);
            _userRepository.UpdateStudent(student);
            if(await _userRepository.SaveAllChangesAsync()) return NoContent();
            return BadRequest("Failed to update student!");  
        }       

        [HttpPost("add-photo")]
        public async Task<ActionResult<StudentPhotoDto>> AddPhoto(IFormFile file){
            var username= User.GetUsername();
            var user = await _userRepository.GetStudentByUsernameAsync(username);
            var result = await _photoService.AddPhotoAsync(file);
            if(result.Error!=null) return BadRequest(result.Error.Message);
            var photo = new StudentPhoto{
                Url=result.SecureUrl.AbsoluteUri,
                PublicId= result.PublicId
            };

            if(user.Photos.Count==0){
                photo.IsMain=true;
            }
            user.Photos.Add(photo);
            if(await _userRepository.SaveAllChangesAsync()){

                return CreatedAtRoute("GetStudent", new {username=user.UserName},
                                        _mapper.Map<StudentPhotoDto>(photo));
            } 

            return BadRequest("Problem occured while adding a photo!");
        }

    }
}