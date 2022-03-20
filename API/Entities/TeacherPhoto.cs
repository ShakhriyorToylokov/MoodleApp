using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("TeacherPhotos")]
    public class TeacherPhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; } // try to create individual course photo for each student and teacher
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}