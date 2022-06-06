namespace API.Entities.CourseDetails
{
    public class QuizFiles
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public string QuizDefintion { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public string FileName { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}