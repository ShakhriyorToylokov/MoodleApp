using System.Collections.Generic;

namespace API.DTOs.Course
{
    public class StudentCoursesUpdateDto
    {
        public string Username { get; set; }
        public ICollection<CourseDto> Courses { get; set; }
        
    }
}