using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using RantBuddy_Common;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace RantBuddy_BusinessDataLogic
{
    public class EmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public void SendEmail(string username, string? content = null)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailSettings.FromName, _emailSettings.FromAddress));
            message.To.Add(new MailboxAddress(_emailSettings.ToName, _emailSettings.ToAddress));
            message.Subject = $"🗣️ New Rant from {username}";

            string emailBody;

            if (string.IsNullOrWhiteSpace(content))
            {
                emailBody = $"A new rant notification from {username}.";
            }
            else
            {
                emailBody = $"A new rant was submitted by {username}:\n\n" +
                            $"\"{content}\"\n\n" +
                            $"— RantBuddy System";
            }

            message.Body = new TextPart("plain") { Text = emailBody };

            using (var client = new SmtpClient())
            {
                var tlsOption = _emailSettings.EnableTls
                    ? MailKit.Security.SecureSocketOptions.StartTls
                    : MailKit.Security.SecureSocketOptions.None;

                client.Connect(_emailSettings.SmtpHost, _emailSettings.SmtpPort, tlsOption);
                client.Authenticate(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }

    }
}

