using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class TeachersController : BaseApiController
    {
        private readonly ITeacherRepository _userRepository;
        private readonly IMapper _mapper;
        public TeachersController(ITeacherRepository userRepository,IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetTeachers()
        {
            var teachers= await _userRepository.GetMemberTeachersAsync();
            return Ok(teachers);    
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<TeacherDto>> GetUser(string username)
        {
            var teacherByUsername= await _userRepository.GetMemberTeacherByUsernameAsync(username);
            var teacherByName= await _userRepository.GetMemberTeacherByNameAsync(username);
            var teacher= (teacherByUsername!=null)? teacherByUsername: teacherByName;
            return teacher;    
        }
    }
}