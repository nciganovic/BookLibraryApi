using Application.Dto.Email;
using Application.Email;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using Application.Settings;

namespace Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly MailSettings mailSettings;

        public SmtpEmailSender(IOptions<MailSettings> options)
        {
            mailSettings = options.Value;
        }

        public void SendEmail(SendEmailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = mailSettings.Host,
                Port = mailSettings.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mailSettings.Mail, mailSettings.Password)
            };

            var message = new MailMessage(mailSettings.Mail, dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
