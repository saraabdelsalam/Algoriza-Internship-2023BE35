using Core_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class EmailSenderService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var sender = "saraelgebaly_11@outlook.com";
            var client = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(sender, "Sara11elgebaly")
            };

            return client.SendMailAsync(
                new MailMessage(from: sender,
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
