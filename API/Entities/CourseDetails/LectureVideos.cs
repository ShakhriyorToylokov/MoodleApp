using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities.CourseDetails
{
    public class LectureVideos
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string NameOfVideo { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}