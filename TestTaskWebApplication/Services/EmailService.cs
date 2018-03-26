using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using TestTaskWebApplication.Infrastructure.Config;

namespace TestTaskWebApplication.Services
{
    public class EmailService : MailTemplate, IMailService
    {
        protected readonly EmailElement Settings;

        public EmailService(EmailElement settings)
        {
            Settings = settings;
        }

        public Task SendAsync(IdentityMessage message)
        {
            MailMessage mailMessage = CreateMessage(Settings.FromAddress, message.Destination, message.Subject, message.Body);
            return SendAsync(mailMessage);
        }

        public Task SendTemplateMessageAsync(string to, string templatePath, object model, bool isBodyHtml = false)
        {
            MailMessage mailMessage = CreateMessage(Settings.FromAddress, to, templatePath, model, isBodyHtml: isBodyHtml);
            return SendAsync(mailMessage);
        }

        private Task SendAsync(MailMessage message)
        {
            SmtpClient client = new SmtpClient(Settings.Host, Settings.Port);

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(Settings.FromAddress, Settings.Password);
            client.EnableSsl = true;

            return client.SendMailAsync(message);
        }
    }
}