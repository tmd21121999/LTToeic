namespace CoreLTToeic.Application.Models.ViewModels;

public class UserAnswerViewModel
{
    public long Id { get; set; }
    public long QuestionId { get; set; }
    public string? SelectedAnswer { get; set; }
    public string? CorrectAnswer { get; set; }
    public bool IsCorrect { get; set; }
}
