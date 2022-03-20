using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Courses")]
    public class Course
    {
        public int Id { get; set; }
        public string NameOfCourse { get; set; }
        public string CourseCode { get; set; }
        public string Definition { get; set; }
        public DateTime LastAccessed { get; set; }  = DateTime.Now;
   //     public ICollection<Photo> Photos { get; set; }
        public ICollection<Teacher> Teacher { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}