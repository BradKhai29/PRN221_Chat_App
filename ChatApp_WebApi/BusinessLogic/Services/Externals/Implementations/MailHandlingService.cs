using BusinessLogic.Models;
using BusinessLogic.Services.Externals.Base;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Options.Models;
using System.Text;

namespace BusinessLogic.Services.Externals.Implementations
{
    internal class MailHandlingService :
        IMailHandlingService
    {
        private readonly MailOptions _mailOptions;

        public MailHandlingService(IOptions<MailOptions> mailOptions)
        {
            _mailOptions = mailOptions.Value;
        }

        public async Task<MailContentModel> GetMailContentAsync(
            string templatePath,
            string to,
            string subject,
            string linkedUri1,
            string linkedUri2,
            CancellationToken cancellationToken)
        {
            var mailTemplate = await File.ReadAllTextAsync(
                path: templatePath,
                cancellationToken: cancellationToken);

            // Build content for the mail.
            var mailBodyBuilder = new StringBuilder(value: mailTemplate);
            
            // Replace the placeholder with specified values.
            mailBodyBuilder.Replace(
                oldValue: MailOptions.Link1_PlaceHolder,
                newValue: _mailOptions.GetFullLink(linkedUri1));

            mailBodyBuilder.Replace(
                oldValue: MailOptions.Link2_PlaceHolder,
                newValue: _mailOptions.GetFullLink(linkedUri2));

            var mailContent = new MailContentModel
            {
                To = to,
                Subject = subject,
                Body = mailBodyBuilder.ToString(),
            };

            return mailContent;
        }

        public Task<bool> IsRealAsync(string email)
        {
            return Task.FromResult(true);
        }

        public async Task<bool> SendMailAsync(MailContentModel mailContent)
        {
            //Init an email for sending.
            MimeMessage email = new()
            {
                Sender = new MailboxAddress(
                    name: _mailOptions.DisplayName,
                    address: _mailOptions.Address)
            };

            // Add the "from" section.
            email.From.Add(
                address: new MailboxAddress(
                    name: _mailOptions.DisplayName,
                    address: _mailOptions.Address)
                );

            //Add the "to" section.
            email.To.Add(
                address: MailboxAddress.Parse(text: mailContent.To));

            //Add the "subject" section.
            email.Subject = mailContent.Subject;

            //Add the "body" section.
            var bodyBuilder = new BodyBuilder()
            {
                HtmlBody = mailContent.Body
            };

            email.Body = bodyBuilder.ToMessageBody();

            using SmtpClient smtp = new();

            try
            {
                await smtp.ConnectAsync(
                    host: _mailOptions.Host,
                    port: _mailOptions.Port,
                    options: SecureSocketOptions.StartTlsWhenAvailable);

                await smtp.AuthenticateAsync(
                    userName: _mailOptions.Address,
                    password: _mailOptions.Password);

                await smtp.SendAsync(message: email);

                await smtp.DisconnectAsync(quit: true);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
