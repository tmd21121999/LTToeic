namespace CoreLTToeic.Application.Models.ViewModels
{
    public class QuestionGroupViewModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
        public string? Audio { get; set; }
        public long? TestId { get; set; }
        public List<string?> Images { get; set; } = new();
        public List<QuestionViewModel> Questions { get; set; } = new();
    }
}
