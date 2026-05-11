using CoreLTToeic.Domain.Enums;

namespace CoreLTToeic.Application.Models.ViewModels
{
    public class TestViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public int Duration { get; set; }
        public int TotalQuestions { get; set; }
        public TestStatus Status { get; set; }
        public string? ListeningAudio { get; set; }
        public string? CategoryName { get; set; }
        public long? TestCategoryId { get; set; }
        public int AttemptCount { get; set; }
    }
}
