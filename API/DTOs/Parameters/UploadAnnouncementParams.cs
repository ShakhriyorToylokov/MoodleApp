using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Parameters
{
    public class UploadAnnouncementParams
    {
        public string CourseCode { get; set; }
        public string Announcement { get; set; }
    }
}