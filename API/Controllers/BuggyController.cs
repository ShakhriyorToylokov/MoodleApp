using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetAuthError(){
            return "You are authorized to see this!";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFoundError(){
            
            var thing = _context.Students.Find(-1);
            if (thing==null)
            {
                return NotFound("The user is not found");
            } 
            return Ok(thing);
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError(){
            var thing = _context.Students.Find(-1);
            var thingToReturn = thing.ToString();
            return thingToReturn;
        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequestError(){
            return BadRequest("This was bad request!");
        }
    }
}