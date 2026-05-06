namespace CoreLTToeic.Infrastructure.Config
{
    public class MailSettings
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; } = 25;
        public bool EnableSsl { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string FromName { get; set; } = string.Empty;
    }
}