using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities.CourseDetails
{
    public class Homework
    {
        public int Id { get; set; }
        public string nameOfHomework { get; set; }
        public string Definition { get; set; }
        public  Course Course { get; set; }
        public  int CourseId { get; set; } 
 
    }
}