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
        public string photoUrl { get; set; }
        public DateTime LastAccessed { get; set; }  = DateTime.Now;
        public ICollection<Faculty> Faculties { get; set; }
        public Teacher Teacher { get; set; } 
        public int TeacherId { get; set; }
        // is it possible to make this one to many, I tried but now worked
        public ICollection<Student> Students { get; set; }

    }
}