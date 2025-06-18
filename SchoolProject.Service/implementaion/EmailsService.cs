using MailKit.Net.Smtp;
using MimeKit;
using SchoolProject.Data.Helpers;
using SchoolProject.Service.Abstracts;
namespace SchoolProject.Service.Implementations
{
    public class EmailsService(EmailSettings emailSettings) : IEmailsService
    {
        #region Fields
        private readonly EmailSettings _emailSettings = emailSettings;

        #endregion
        #region Constructors

        #endregion
        #region Handle Functions
        public async Task<string> SendEmail(string email, string Message, string? reason)
        {
            try
            {
                //sending the Message of passwordResetLink
                using var client = new SmtpClient();
                await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
                client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);
                var bodybuilder = new BodyBuilder
                {
                    HtmlBody = $"{Message}",
                    TextBody = "wellcome",
                };
                var message = new MimeMessage
                {
                    Body = bodybuilder.ToMessageBody()
                };
                message.From.Add(new MailboxAddress(" Belal", _emailSettings.FromEmail));
                message.To.Add(new MailboxAddress("testing", email));
                message.Subject = reason == null ? " Belal " : reason;
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                //end of sending email
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
        }
        #endregion
    }
}