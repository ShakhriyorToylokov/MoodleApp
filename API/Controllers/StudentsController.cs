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
    public class StudentsController : BaseApiController
    {
        private readonly IStudentRepository _userRepository;
        private readonly IMapper _mapper;
        public StudentsController(IStudentRepository userRepository,IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students= await _userRepository.GetMemberStudentsAsync();
            return Ok(students);    
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<AppUser>> GetStudent(string username)
        {
            var studentUsername  =  await _userRepository.GetMemberStudentAsync(username);
            var studentName  =  await _userRepository.GetMemberStudentByNameAsync(username);
            var student =  (studentUsername!=null)? studentUsername : studentName;
            return Ok(student);    
        }

        
    }
}