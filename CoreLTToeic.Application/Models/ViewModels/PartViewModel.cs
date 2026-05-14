using CoreLTToeic.Domain.Enums;

namespace CoreLTToeic.Application.Models.ViewModels
{
    public class PartViewModel
    {
        public long Id { get; set; }
        public ToeicLRPart PartNum { get; set; }
        public string? Content { get; set; }
        public long? TestId { get; set; }
        public int QuestionCount { get; set; }
        public int QuestionGroupCount { get; set; }
    }
}
