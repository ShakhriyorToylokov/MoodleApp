using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class CoursesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CoursesController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses(){
            var courses= await _context.Courses.ProjectTo<CourseDto>(_mapper.ConfigurationProvider).AsSingleQuery() //** Might cause issue
                .ToListAsync();
            return Ok(courses);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CourseDto>> GetCourse(string name)
        {
            var courseByName = await _context.Courses.ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                .AsSingleQuery().SingleOrDefaultAsync(x=>x.NameOfCourse.ToLower()==name.ToLower());
            
            var courseByCourseCode = await _context.Courses.ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                .AsSingleQuery().SingleOrDefaultAsync(x=>x.CourseCode.ToLower()==name.ToLower());
            var course  = (courseByName!=null)?courseByName:courseByCourseCode;
            return Ok(course);    
        }
}
}