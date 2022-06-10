using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Course
{
    public class HomeworkDto
    {
        public int Id { get; set; }
        public string nameOfHomework { get; set; }
        public string Definition { get; set; }
    }
}