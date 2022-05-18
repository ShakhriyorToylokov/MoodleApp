using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Course
{
    public class RegisterCourseDto
    {
        public string NameOfCourse { get; set; }
        public string CourseCode { get; set; }
        public string Definition { get; set; }
        public string TeacherName { get; set; }
        public int TeacherId { get; set; }
    }
}