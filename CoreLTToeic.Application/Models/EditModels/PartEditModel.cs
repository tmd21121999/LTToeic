using CoreLTToeic.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CoreLTToeic.Application.Models.EditModels
{
    public class PartEditModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Part")]
        public ToeicLRPart PartNum { get; set; } = ToeicLRPart.Part1;

        public string? Content { get; set; }

        [Required]
        public long TestId { get; set; }
    }
}
