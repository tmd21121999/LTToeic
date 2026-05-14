using System.ComponentModel.DataAnnotations;

namespace CoreLTToeic.Application.Models.EditModels
{
    public class QuestionEditModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Nội dung câu hỏi không được để trống")]
        public string Content { get; set; } = null!;

        public string? Answer1 { get; set; }
        public string? Answer2 { get; set; }
        public string? Answer3 { get; set; }
        public string? Answer4 { get; set; }

        [Required(ErrorMessage = "Đáp án đúng không được để trống")]
        public string CorrectAnswer { get; set; } = null!;

        public string? Audio { get; set; }
        public string? Image { get; set; }
        public string? Transcript { get; set; }
        public int OrderNumber { get; set; }
        public long? PartId { get; set; }
        public long TestId { get; set; }
        public long? QuestionGroupId { get; set; }
    }
}
