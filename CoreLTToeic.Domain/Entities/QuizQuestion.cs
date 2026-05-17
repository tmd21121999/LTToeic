namespace CoreLTToeic.Domain.Entities
{
    public class QuizQuestion
    {
        public long Id { get; set; }
        public long? LessonId { get; set; }
        public CourseLesson? Lesson { get; set; }
        public string Question { get; set; } = string.Empty;
        public string? Type { get; set; }
        public int? OrderIndex { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public QuizQuestionOption? Option { get; set; }
    }
}
