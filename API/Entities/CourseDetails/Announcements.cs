using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities.CourseDetails
{
    public class Announcements
    {
        public int Id { get; set; }
        public string Announcement { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}