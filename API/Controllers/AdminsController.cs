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
    public class AdminsController:BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public AdminsController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDto>>> GetTeachers()
        {
             var admins= await _context.Admin.ProjectTo<AdminDto>(_mapper.ConfigurationProvider).AsSingleQuery() //** Might cause issue
                .ToListAsync();
             return admins;    
        }

        [HttpGet("{username}",Name ="GetAdmin")]
        public async Task<ActionResult<AdminDto>> GetUser(string username)
        {
            var adminByUsername= await _context.Admin.Include(x=>x.RegisterFiles).AsSplitQuery().
                SingleOrDefaultAsync(x=>x.UserName.ToLower() == username.ToLower());
            _mapper.Map<AdminDto>(adminByUsername);
            return _mapper.Map<AdminDto>(adminByUsername);    
        }

    }
}