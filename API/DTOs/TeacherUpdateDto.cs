using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class TeacherUpdateDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string InsNum { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }        
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Faculty { get; set; }
    }
}