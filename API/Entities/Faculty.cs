using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}