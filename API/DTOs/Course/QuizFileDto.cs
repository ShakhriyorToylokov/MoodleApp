namespace API.DTOs.Course
{
    public class QuizFileDto
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public string QuizDefintion { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
    }
}