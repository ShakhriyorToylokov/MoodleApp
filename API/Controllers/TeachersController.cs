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
        public async Task<ActionResult> UpdateStudent(TeacherUpdateDto teacherUpdateDto){
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
    }
}