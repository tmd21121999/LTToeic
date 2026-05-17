using CoreLTToeic.Domain.Enums;

namespace CoreLTToeic.Application.Models.EditModels
{
    public class CourseEditModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Objective { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? PreviewVideoUrl { get; set; }
        public decimal Price { get; set; }
        public CourseLevel Level { get; set; } = CourseLevel.Beginner;
        public CourseStatus Status { get; set; } = CourseStatus.Draft;
    }
}
