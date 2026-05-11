namespace CoreLTToeic.Application.Models.ViewModels
{
    public class QuestionViewModel
    {
        public long Id { get; set; }
        public string? Content { get; set; }
        public string? Answer1 { get; set; }
        public string? Answer2 { get; set; }
        public string? Answer3 { get; set; }
        public string? Answer4 { get; set; }
        public string? CorrectAnswer { get; set; }
        public string? Audio { get; set; }
        public string? Image { get; set; }
        public string? Transcript { get; set; }
        public int OrderNumber { get; set; }
        public long? PartId { get; set; }
        public long? TestId { get; set; }
    }
}
