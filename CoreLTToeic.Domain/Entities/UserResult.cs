using CoreLTToeic.Domain.Enums;

namespace CoreLTToeic.Domain.Entities
{
    public class UserResult
    {
        public long Id { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
        public int SkippedAnswers { get; set; }
        public int ListeningCorrects { get; set; }
        public int ReadingCorrects { get; set; }
        public int TotalListeningQuestions { get; set; }
        public int TotalReadingQuestions { get; set; }
        public int ListeningScore { get; set; }
        public int ReadingScore { get; set; }
        public int TotalScore { get; set; }
        public int CompletionTime { get; set; }
        public float Accuracy { get; set; }
        public DateTime? CompletedAt { get; set; }
        public AttemptStatus AttemptStatus { get; set; } = AttemptStatus.NotStarted;
        public TestMode TestMode { get; set; } = TestMode.Practice;
        public string UserId { get; set; } = null!;
        public AppUser? User { get; set; }
        public long TestId { get; set; }
        public Test? Test { get; set; }
        public ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}
