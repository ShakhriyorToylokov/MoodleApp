using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Course
{
    public class CourseUploadFileDto
    {
        
        public int Id { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public bool IsOutline { get; set; }

    }
}