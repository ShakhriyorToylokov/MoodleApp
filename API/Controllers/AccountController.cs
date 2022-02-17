using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class AccountController : BaseApiController
    {
        private readonly ITokenService _tokenService;

        private readonly DataContext _context;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register-student")]
        public async Task<ActionResult<UserDto>> RegisterStudent(RegisterDto registerDto)
        {

            if(await StudentExists(registerDto.Username)) return BadRequest("Username is taken!");
            using var hmac = new HMACSHA512();
            
            var student = new Student{
                UserName=registerDto.Username.ToLower(),
                PasswordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt=hmac.Key
            }; 
            
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            
            return new UserDto{
                Username=student.UserName,
                Token= _tokenService.CreateToken(student)
            };
        }

        [HttpPost("register-teacher")]
        public async Task<ActionResult<UserDto>> RegisterTeacher(RegisterDto registerDto)
        {

            if(await TeacherExists(registerDto.Username)) return BadRequest("Username is taken!");
            using var hmac = new HMACSHA512();
            
            var teacher = new Teacher{
                UserName=registerDto.Username.ToLower(),
                PasswordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt=hmac.Key
            }; 
            
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return new UserDto{
                Username=teacher.UserName,
                Token= _tokenService.CreateToken(teacher)
            };
        }

        [HttpPost("login-student")]

        public async Task<ActionResult<UserDto>> LoginAsStudent(LoginDto loginDto)
        {
            var user = await _context.Students.SingleOrDefaultAsync(x=>x.UserName==loginDto.Username.ToLower()); 
            if(user == null) return Unauthorized("Invalid Username!");
            using var hmac= new HMACSHA512(user.PasswordSalt);
            var computedHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i]!=user.PasswordHash[i])
                {
                    return Unauthorized("Invalid Password!");
                }
            }
            return new UserDto{
                Username=user.UserName,
                Token= _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login-teacher")]

        public async Task<ActionResult<UserDto>> LoginAsTeacher(LoginDto loginDto)
        {
            var user = await _context.Teachers.SingleOrDefaultAsync(x=>x.UserName==loginDto.Username.ToLower()); 
            if(user == null) return Unauthorized("Invalid Username!");
            using var hmac= new HMACSHA512(user.PasswordSalt);
            var computedHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i]!=user.PasswordHash[i])
                {
                    return Unauthorized("Invalid Password!");
                }
            }
            return new UserDto{
                Username=user.UserName,
                Token= _tokenService.CreateToken(user)
            };
        }
        private async Task<bool> StudentExists(string username){
            if(await _context.Students.AnyAsync(x=>x.UserName==username.ToLower())){
                return true;
            }
            return false;
        }

        private async Task<bool> TeacherExists(string username){
            if(await _context.Teachers.AnyAsync(x=>x.UserName==username.ToLower())){
                return true;
            }
            return false;
        }
    }
}
















/*

*/