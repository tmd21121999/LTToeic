using CoreLTToeic.Domain.Enums;

namespace CoreLTToeic.Application.Models.EditModels
{
    public class CourseLessonEditModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public LessonType? Type { get; set; }
        public int? Duration { get; set; }
        public int? OrderIndex { get; set; }
        public bool? IsFree { get; set; }
        public string? Content { get; set; }
        public string? VideoUrl { get; set; }
    }
}
