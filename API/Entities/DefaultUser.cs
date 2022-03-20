using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;

namespace API.Entities
{
    [Table("DefaultUsers")]
    public class DefaultUser:AppUser
    {
        // public string Name { get; set; }
        // public string Surname { get; set; }
        // public string StdNum { get; set; }
        // public string Email { get; set; }
        // public string Country { get; set; }        
        // public string Gender { get; set; }
        // public DateTime DateOfBirth { get; set; }
        // public DateTime Created { get; set; }=DateTime.Now;
        // public DateTime LastActive { get; set; }=DateTime.Now;
        // public ICollection<StudentPhoto> Photos { get; set; }
        // public ICollection<StudentCourses> Courses { get; set; }
        // public ICollection<Teacher> Teachers { get; set; }
        // public int GetAge(){ 
        //     return DateOfBirth.CalculateAge();
        // }
    }
}