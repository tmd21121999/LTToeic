using System.ComponentModel.DataAnnotations;

namespace CoreLTToeic.Domain.Entities
{
    public class QuestionGroupImage
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(500)]
        public string? Image { get; set; }

        public long? QuestionGroupId { get; set; }
        public QuestionGroup? QuestionGroup { get; set; }
    }
}
