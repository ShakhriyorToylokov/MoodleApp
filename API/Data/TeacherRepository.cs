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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TeacherRepository(DataContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public void UpdateTeacher(Teacher teacher)
        {
            _context.Entry(teacher).State=EntityState.Modified;
        }
        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<Teacher> GetTeacherByUsernameAsync(string username)
        {
            return await _context.Teachers.Include(x=>x.Courses).Include(x=>x.Photos).AsSplitQuery().
                SingleOrDefaultAsync(x=>x.UserName.ToLower() == username.ToLower());
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            return await _context.Teachers.Include(x=>x.Courses).Include(x=>x.Photos).AsSplitQuery().ToListAsync();
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TeacherDto>> GetMemberTeachersAsync()
        {
              return await _context.Teachers
                .ProjectTo<TeacherDto>(_mapper.ConfigurationProvider).AsSingleQuery()
                .ToListAsync();
        }

        public async Task<TeacherDto> GetMemberTeacherByUsernameAsync(string username)
        {
            return await _context.Teachers.Where(x=>x.UserName.ToLower() == username.ToLower())
                .ProjectTo<TeacherDto>(_mapper.ConfigurationProvider).AsSingleQuery()
                .SingleOrDefaultAsync();
        }
        public async Task<TeacherDto> GetMemberTeacherByNameAsync(string name)
        {
            return await _context.Teachers.Where(x=>x.Name.ToLower() == name.ToLower())
                .ProjectTo<TeacherDto>(_mapper.ConfigurationProvider).AsSingleQuery()
                .SingleOrDefaultAsync();
        }
    }
}