using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        [StringLength(15,MinimumLength = 6)]
        public string Username { get; set; }
        [Required]
        [StringLength(15 ,MinimumLength = 6 )]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string StdNum { get; set; }
        public string InsNum { get; set; }
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Faculty { get; set; }
    }
}