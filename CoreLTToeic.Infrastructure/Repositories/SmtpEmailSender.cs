using CoreLTToeic.Application.Interfaces;
using CoreLTToeic.Infrastructure.Config;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace CoreLTToeic.Application.Business
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly MailSettings _settings;

        public SmtpEmailSender(IOptions<MailSettings> options)
        {
            _settings = options.Value ?? new MailSettings();
        }

        public async Task SendEmailAsync(string to, string subject, string htmlMessage)
        {
            if (string.IsNullOrWhiteSpace(to))
            {
                return;
            }

            using var message = new MailMessage
            {
                From = new MailAddress(_settings.From, _settings.FromName),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            message.To.Add(to);

            using var client = new SmtpClient(_settings.Host, _settings.Port)
            {
                EnableSsl = _settings.EnableSsl
            };

            if (!string.IsNullOrEmpty(_settings.Username))
            {
                client.Credentials = new NetworkCredential(_settings.Username, _settings.Password);
            }

            await client.SendMailAsync(message);
        }
    }
}