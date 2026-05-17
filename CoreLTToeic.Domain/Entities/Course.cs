using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreLTToeic.Domain.Enums;

namespace CoreLTToeic.Domain.Entities
{
    public class Course
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
        public string? Objective { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? PreviewVideoUrl { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public CourseStatus Status { get; set; }
        public CourseLevel Level { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<CourseSection> Sections { get; set; } = new List<CourseSection>();
        public ICollection<CourseEnrollment> Enrollments { get; set; } = new List<CourseEnrollment>();
        public ICollection<CourseReview> Reviews { get; set; } = new List<CourseReview>();
    }
}
