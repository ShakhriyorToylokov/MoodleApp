using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class FacultiesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public FacultiesController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacultyDto>>> GetFaculties(){
            var faculties= await _context.Faculties.ProjectTo<FacultyDto>(_mapper.ConfigurationProvider).AsSingleQuery() //** Might cause issue
                .ToListAsync();
            return Ok(faculties);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<FacultyDto>> GetFaculty(string name)
        {
            var facultyByName = await _context.Faculties.ProjectTo<FacultyDto>(_mapper.ConfigurationProvider)
                .AsSingleQuery().SingleOrDefaultAsync(x=>x.FacultyName.ToLower()==name.ToLower());
            
            return Ok(facultyByName);    
        }
    }
}