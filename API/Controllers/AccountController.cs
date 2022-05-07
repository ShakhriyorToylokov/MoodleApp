using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class AccountController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly ISeedService _seedService;

        private readonly DataContext _context;
        public AccountController(DataContext context, ITokenService tokenService,
                                IFileService fileService,IMapper mapper,ISeedService seedService)
        {
            _seedService = seedService;
            _mapper = mapper;
            _fileService = fileService;
            _tokenService = tokenService;
            _context = context;
        }

         [HttpPost("login")]

        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto){
            
            var username = loginDto.Username.ToLower();
            var findUserType = username.Substring(0,3);
            
            if(String.Equals(findUserType,"std")){
                return await LoginAsStudent(loginDto);
            }
            else if(String.Equals(findUserType,"ins")){
                return await LoginAsTeacher(loginDto);
            }
            else if(username.Contains("@admin")){
                return await LoginAsAdmin(loginDto);
            }
            else{
                return Unauthorized("Invalid Username!!!");
            }
        }
        [HttpPost("register")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto){
            var username = registerDto.Username.ToLower();
            var findUserType = username.Substring(0,3);
            
            if(String.Equals(findUserType,"std")){
                return await RegisterStudent(registerDto);
            }
            else if(String.Equals(findUserType,"ins")){
                return await RegisterTeacher(registerDto);
            }
            else{
                return BadRequest("Invalid Username Type!!!\n Username should start with std or ins !!!");
            }
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

        [HttpPost("register-admin")]
        public async Task<ActionResult<UserDto>> RegisterAdmin(RegisterDto registerDto)
        {

            if(await AdminExists(registerDto.Username)) return BadRequest("Username is taken!");
            using var hmac = new HMACSHA512();
            
            var admin = new Adminstrator{
                UserName=registerDto.Username.ToLower(),
                PasswordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt=hmac.Key
            }; 
            
            _context.Admin.Add(admin);
            await _context.SaveChangesAsync();
            
            return new UserDto{
                Username=admin.UserName,
                Token= _tokenService.CreateToken(admin)
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
            var user = await _context.Students.Include(x=>x.Photos).SingleOrDefaultAsync(x=>x.UserName==loginDto.Username.ToLower()); 
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
                Token= _tokenService.CreateToken(user),
                PhotoUrl= user.Photos.FirstOrDefault(x=>x.IsMain)?.Url
            };
        }

        [HttpPost("login-admin")]

        public async Task<ActionResult<UserDto>> LoginAsAdmin(LoginDto loginDto)
        {
            var user = await _context.Admin.SingleOrDefaultAsync(x=>x.UserName==loginDto.Username.ToLower()); 
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
            var user = await _context.Teachers.Include(p=>p.Photos).
                SingleOrDefaultAsync(x=>x.UserName==loginDto.Username.ToLower()); 
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
                Token= _tokenService.CreateToken(user),
                PhotoUrl= user.Photos.FirstOrDefault(x=>x.IsMain)?.Url
            };
        }

        [HttpPost("register-by-file/{userType}")]
        public async Task<ActionResult<RegisterFileDto>> RegisterByFile(IFormFile file,string userType){
            
            try
            {
                if (userType=="Student")
                {
                    await _seedService.SeedStudents(_context, file);                    
                }
                else if (userType=="Teacher")
                {
                    await _seedService.SeedTeachers(_context, file);                    
                }
                else
                {
                    return BadRequest("Not a proper user type to register!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            } 
            var result = file.FileName.Contains(".pdf")? await _fileService.AddPDFFileAsync(file):
                                                         await _fileService.AddFileAsync(file);                
            var admin = await _context.Admin.Include(x=>x.RegisterFiles).AsSplitQuery()
                                            .SingleOrDefaultAsync(x=>x.AdminType=="Main");
             
            if(result.Error!=null) return BadRequest(result.Error.Message);
            var uploadingFile = new RegisterFile{ 
                Url=result.SecureUrl.AbsoluteUri, 
                PublicId= result.PublicId,
                FileName= file.FileName  
            };
            admin.RegisterFiles.Add(uploadingFile);
            if(await _context.SaveChangesAsync()>0){ 

                
                 return  _mapper.Map<RegisterFileDto>(uploadingFile);
            } 

            return BadRequest("Problem occured while adding a file!");
        }
        [HttpDelete("delete-file/{fileId}")]
        public async Task<ActionResult> DeleteFile(int fileId){
         
            var admin = await _context.Admin.Include(x=>x.RegisterFiles).AsSplitQuery()
                                            .SingleOrDefaultAsync(x=>x.AdminType=="Main");
          
           
            var file= admin.RegisterFiles.FirstOrDefault(x=>x.Id==fileId);
            if(file==null) return NotFound();
            if(file.PublicId!=null){
                var result= await _fileService.DeleteFileAsync(file.PublicId);
                if(result.Error!=null) return BadRequest(result.Error.Message);

            }
            admin.RegisterFiles.Remove(file);
            if(await _context.SaveChangesAsync()>0) return Ok();

            return BadRequest("Failed to delete a file!");
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
        private async Task<bool> AdminExists(string username){
            if(await _context.Admin.AnyAsync(x=>x.UserName==username.ToLower())){
                return true;
            }
            return false;
        }
    }
}
















/*

*/