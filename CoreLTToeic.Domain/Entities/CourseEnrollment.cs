using CoreLTToeic.Domain.Enums;

namespace CoreLTToeic.Domain.Entities
{
    public class CourseEnrollment
    {
        public long Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public AppUser User { get; set; } = null!;
        public long CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public EnrollmentStatus? Status { get; set; }
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    }
}
