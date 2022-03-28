using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string NameOfCourse { get; set; }
        public string CourseCode { get; set; }
        public string Definition { get; set; }
        public string photoUrl { get; set; }
        public DateTime LastAccessed { get; set; }

    }
}