using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities.CourseDetails
{
    public class CourseUploadFile:FileCommonProps
    {
        
      
        public Course Course { get; set; }
        public int CourseId { get; set; } 
 
    }
}