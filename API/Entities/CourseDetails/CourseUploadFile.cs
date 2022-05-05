using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities.CourseDetails
{
    public class CourseUploadFile
    {
        
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public string FileName { get; set; }
        public bool IsOutline { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; } 
 
    }
}