namespace CoreLTToeic.Domain.Entities
{
    public class LessonCompletion
    {
        public long Id { get; set; }
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
        public long? LessonId { get; set; }
        public CourseLesson? Lesson { get; set; }
        public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
    }
}
