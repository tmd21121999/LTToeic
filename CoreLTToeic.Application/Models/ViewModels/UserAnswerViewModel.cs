namespace CoreLTToeic.Application.Models.ViewModels;

public class UserAnswerViewModel
{
    public long Id { get; set; }
    public long QuestionId { get; set; }
    public string? SelectedAnswer { get; set; }
    public string? CorrectAnswer { get; set; }
    public bool IsCorrect { get; set; }

    // Question detail fields (for result review)
    public string? QuestionContent { get; set; }
    public string? Answer1 { get; set; }
    public string? Answer2 { get; set; }
    public string? Answer3 { get; set; }
    public string? Answer4 { get; set; }
    public string? Audio { get; set; }
    public string? Image { get; set; }
    public string? Transcript { get; set; }
    public string? Explanation { get; set; }
    public int OrderNumber { get; set; }
    public int PartNum { get; set; }
    public long? QuestionGroupId { get; set; }
}
