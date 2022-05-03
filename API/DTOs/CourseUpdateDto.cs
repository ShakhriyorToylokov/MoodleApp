using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Course;

namespace API.DTOs
{
    public class CourseUpdateDto
    {
        public string NameOfCourse { get; set; }
        public string CourseCode { get; set; }
        public string Definition { get; set; }
       // public ICollection<AnnouncementUpdateDto> Announcements { get; set; }
       
    }
}