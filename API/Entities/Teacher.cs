using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;

namespace API.Entities
{
    public class Teacher : AppUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int InsNum { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }        
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }=DateTime.Now;
        public DateTime LastActive { get; set; }=DateTime.Now;
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Student> Students { get; set; }
        public Photo Photo { get; set; }
        public int GetAge(){
            return DateOfBirth.CalculateAge();
        }
    }
}