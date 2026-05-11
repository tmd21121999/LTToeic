using System.ComponentModel.DataAnnotations;

namespace CoreLTToeic.Domain.Entities
{
    public class UserAnswer
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(10)]
        public string? SelectedAnswer { get; set; }

        public bool IsCorrect { get; set; }

        public long UserResultId { get; set; }
        public UserResult? UserResult { get; set; }

        public long QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
