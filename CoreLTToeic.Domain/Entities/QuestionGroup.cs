using System.ComponentModel.DataAnnotations;

namespace CoreLTToeic.Domain.Entities
{
    public class QuestionGroup
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(500)]
        public string? Audio { get; set; }

        public string? Content { get; set; }

        [MaxLength(256)]
        public string? Name { get; set; }

        public float StartTimestamp { get; set; }

        public long? PartId { get; set; }
        public Part? Part { get; set; }

        public long? TestId { get; set; }
        public Test? Test { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<QuestionGroupImage> Images { get; set; } = new List<QuestionGroupImage>();
    }
}
