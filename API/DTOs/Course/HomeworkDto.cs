using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Course
{
    public class HomeworkDto
    {
        public int Id { get; set; }
        public string HomeworkName { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public string PublicId { get; set; }

    }
}