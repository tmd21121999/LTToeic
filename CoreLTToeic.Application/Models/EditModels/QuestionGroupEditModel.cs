namespace CoreLTToeic.Application.Models.EditModels
{
    public class QuestionGroupEditModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
        public string? Audio { get; set; }
        public long TestId { get; set; }
        public List<string> Images { get; set; } = new();
        public List<QuestionEditModel> ChildQuestions { get; set; } = new();
    }
}
