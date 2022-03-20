using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class TeacherCourses 
    {
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}