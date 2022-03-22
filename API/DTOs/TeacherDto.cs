using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Username { get; set; }  
        public string Name { get; set; }
        public string Surname { get; set; }
        public string InsNum { get; set; }
        public string PhotoUrl { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }        
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Faculty { get; set; }
        public ICollection<CourseDto> Courses { get; set; }
        public ICollection<TeacherPhotoDto> Photos { get; set; }
    }
}