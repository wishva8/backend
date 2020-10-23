using MimeKit;
using Order_Management.Services.Contracts;
using System;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Order_Management.Services.Support
{
    public class EmailService : IEmailService
    {

        public async Task SendEmail(string receiverEmail, string subject, string content)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress("Self", "johnperera0223@gmail.com"));
                mimeMessage.To.Add(new MailboxAddress("Self", receiverEmail));
                mimeMessage.Subject = subject;
                mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = content };

                using (MailKit.Net.Smtp.SmtpClient smtpClient = new MailKit.Net.Smtp.SmtpClient())
                {
                    await smtpClient.ConnectAsync("smtp.gmail.com", 587);
                    await smtpClient.AuthenticateAsync("johnperera0223@gmail.com", "adoojohn");
                    await smtpClient.SendAsync(mimeMessage);
                    await smtpClient.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                int i = 5;
            }
        }

    }
}
