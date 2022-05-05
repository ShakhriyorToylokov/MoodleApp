using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Parameters
{
    public class AddVideoParams
    {
        public string CourseCode { get; set; }
        public string VideoUrl { get; set; }
        public string Name { get; set; }
    }
}