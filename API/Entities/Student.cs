using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;

namespace API.Entities
{
    public class Student : AppUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StdNum { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }        
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }=DateTime.Now;
        public DateTime LastActive { get; set; }=DateTime.Now;
        public string Faculty { get; set; }
        public ICollection<StudentPhoto> Photos { get; set; }        
        public ICollection<Course> Courses { get; set; }
        public int GetAge(){ 
            return DateOfBirth.CalculateAge();
        }
    }
}