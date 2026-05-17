namespace CoreLTToeic.Domain.Entities
{
    public class CourseSection
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int? OrderIndex { get; set; }

        public long CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<CourseLesson> Lessons { get; set; } = new List<CourseLesson>();
    }
}
