using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System.Net.Mail;

namespace ODC_Task2__MVC_.Data.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //configure email
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse("info@store.com"));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = subject;
            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

            //send email
            using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
            {
                emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("ahmedsayed74727472@gmail.com", "jxnljghzdaibcejl");
                emailClient.Send(emailToSend);
                emailClient.Disconnect(true);
            }
            return Task.CompletedTask;
        }
    }
}
