using CoreLTToeic.Domain.Enums;

namespace CoreLTToeic.Application.Models.EditModels;

public class UserResultEditModel
{
    public long TestId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public TestMode TestMode { get; set; } = TestMode.Practice;
    public List<UserAnswerEditModel> Answers { get; set; } = [];
}
