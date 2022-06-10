namespace API.Entities.CourseDetails
{
    public class StudentHomework
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public string PublicId { get; set; }
        public string HomeworkName { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}