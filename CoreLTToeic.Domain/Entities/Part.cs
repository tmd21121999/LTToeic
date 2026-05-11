namespace CoreLTToeic.Domain.Entities
{
    public class Part
    {
        public long Id { get; set; }
        public string? Content { get; set; }
        public int PartNum { get; set; }
        public float StartTimestamp { get; set; }
        public long? TestId { get; set; }
        public Test? Test { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<QuestionGroup> QuestionGroups { get; set; } = new List<QuestionGroup>();
    }
}
