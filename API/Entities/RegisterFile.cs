using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class RegisterFile
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public string FileName { get; set; }
        public Adminstrator Admin { get; set; }
        public int AdminId { get; set; }
    }
}