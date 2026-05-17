namespace CoreLTToeic.Domain.Entities
{
    public class CourseReview
    {
        public long Id { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public string UserId { get; set; } = string.Empty;
        public AppUser User { get; set; } = null!;
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
