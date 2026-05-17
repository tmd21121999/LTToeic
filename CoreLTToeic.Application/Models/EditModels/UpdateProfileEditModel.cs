namespace CoreLTToeic.Application.Models.EditModels
{
    public class UpdateProfileEditModel
    {
        public string FullName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
