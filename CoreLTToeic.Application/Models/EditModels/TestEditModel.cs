using CoreLTToeic.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CoreLTToeic.Application.Models.EditModels
{
    public class TestEditModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Thời gian không được để trống")]
        [Range(1, 999, ErrorMessage = "Thời gian phải lớn hơn 0")]
        public int Duration { get; set; }

        public int TotalQuestions { get; set; }
        public TestStatus Status { get; set; } = TestStatus.Active;
        public string? ListeningAudio { get; set; }
        public long? TestCategoryId { get; set; }
    }
}
