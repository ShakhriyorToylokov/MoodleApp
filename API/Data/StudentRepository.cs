using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public StudentRepository(DataContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

       

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> GetStudentByUsernameAsync(string username)
        {
            return await _context.Students.Include(x=>x.Courses).Include(x=>x.Photos).Include(x=>x.Homeworks).AsSplitQuery().
                SingleOrDefaultAsync(x=>x.UserName.ToLower() == username.ToLower());
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _context.Students.Include(x=>x.Courses).Include(x=>x.Photos).AsSplitQuery().ToListAsync();
        }

         public async Task<IEnumerable<StudentDto>> GetMemberStudentsAsync()
        {
            return await _context.Students
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider).AsSingleQuery() 
                .ToListAsync();
        }
        
        public async Task<StudentDto> GetMemberStudentAsync(string username)
        {
            return await _context.Students.Where(x=>x.UserName.ToLower()==username.ToLower())
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider).AsSingleQuery()
                .SingleOrDefaultAsync();
        }
        public async Task<StudentDto> GetMemberStudentByNameAsync(string name)
        {
            return await _context.Students.Where(x=>x.Name.ToLower()==name.ToLower())
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider).AsSingleQuery()
                .SingleOrDefaultAsync();
        }
        public async Task<bool> SaveAllChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateStudent(Student student)
        {
            
            _context.Entry(student).State=EntityState.Modified;
        }

        
    }
}