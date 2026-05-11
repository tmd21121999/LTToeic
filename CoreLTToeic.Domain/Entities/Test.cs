using CoreLTToeic.Domain.Enums;

namespace CoreLTToeic.Domain.Entities
{
    public class Test
    {
        public long Id { get; set; }
        public int Duration { get; set; }
        public string? ListeningAudio { get; set; }
        public TestStatus Status { get; set; } = TestStatus.Active;
        public string Title { get; set; } = null!;
        public int TotalQuestions { get; set; }
        public long? TestCategoryId { get; set; }
        public TestCategory? TestCategory { get; set; }
        public ICollection<Part> Parts { get; set; } = new List<Part>();
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<QuestionGroup> QuestionGroups { get; set; } = new List<QuestionGroup>();
        public ICollection<UserResult> UserResults { get; set; } = new List<UserResult>();
    }
}
