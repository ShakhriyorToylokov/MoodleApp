using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Course;
using API.Entities;

namespace API.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Username { get; set; }  
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StdNum { get; set; }
        public string PhotoUrl { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }        
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Faculty { get; set; }
        public ICollection<StudentPhotoDto> Photos { get; set; }        
        public ICollection<CourseDto> Courses { get; set; }
        public ICollection<StudentHomeworkDto> Homeworks { get; set; }

    }
}