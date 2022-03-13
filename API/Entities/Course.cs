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
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public ICollection<Student> Students { get; set; }
        public Photo Photo { get; set; }
    }
}