namespace CoreLTToeic.Application.Models.ViewModels
{
    public class CourseSectionViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int? OrderIndex { get; set; }
        public int LessonCount { get; set; }
        public List<CourseLessonViewModel> Lessons { get; set; } = new();
    }
}
