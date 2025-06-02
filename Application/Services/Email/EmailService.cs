using Castle.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Application.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly EmailTemplateEngine _templateEngine;

        public EmailService(IOptions<EmailSettings> options, EmailTemplateEngine templateEngine)
        {
            _emailSettings = options.Value;
            _templateEngine = templateEngine;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string templateName, Dictionary<string, string> placeholders)
        {
            string body = await _templateEngine.LoadTemplateAsync(templateName, placeholders);

            var smtpClient = new SmtpClient(_emailSettings.SmtpServer)
            {
                Port = _emailSettings.Port,
                Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.From),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
