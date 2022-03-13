using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}