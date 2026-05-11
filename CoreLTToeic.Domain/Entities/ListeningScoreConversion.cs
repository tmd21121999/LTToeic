using System.ComponentModel.DataAnnotations;

namespace CoreLTToeic.Domain.Entities
{
    public class ListeningScoreConversion
    {
        [Key]
        public long Id { get; set; }

        public int Correct { get; set; }
        public int Score { get; set; }
    }
}
