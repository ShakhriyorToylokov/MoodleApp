using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Course
{
    public class LectureVideosDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string NameOfVideo { get; set; }
    }
}