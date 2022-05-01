using System;
using System.Collections.Generic;
using API.DTOs.Course;

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
        public ICollection<AnnouncementDto> Announcements { get; set; }
        public ICollection<CourseUploadFileDto> CourseFiles { get; set; }
        public ICollection<LectureVideosDto> LectureVideos { get; set; }

    }
}