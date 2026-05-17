using System.ComponentModel.DataAnnotations;

namespace CoreLTToeic.Domain.Entities
{
    public class Question
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(500)]
        public string? Answer1 { get; set; }

        [MaxLength(500)]
        public string? Answer2 { get; set; }

        [MaxLength(500)]
        public string? Answer3 { get; set; }

        [MaxLength(500)]
        public string? Answer4 { get; set; }

        [MaxLength(500)]
        public string? Audio { get; set; }

        public string? Content { get; set; }

        [MaxLength(10)]
        public string? CorrectAnswer { get; set; }

        [MaxLength(500)]
        public string? Image { get; set; }

        public int OrderNumber { get; set; }
        public float StartTimestamp { get; set; }

        public string? Transcript { get; set; }

        public string? Explanation { get; set; }

        public long? PartId { get; set; }
        public Part? Part { get; set; }

        public long? QuestionGroupId { get; set; }
        public QuestionGroup? QuestionGroup { get; set; }

        public long? TestId { get; set; }
        public Test? Test { get; set; }

        public ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}
