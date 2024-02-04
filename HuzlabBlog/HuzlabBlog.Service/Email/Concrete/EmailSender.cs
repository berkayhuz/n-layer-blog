using HuzlabBlog.Service.Email.Abstractions;
using System.Net;
using System.Net.Mail;

namespace HuzlabBlog.Service.Email.Concrete
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("lmasteregol@gmail.com", "bgissupfqwbuklcz");
                    smtpClient.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("lmasteregol@gmail.com");
                    mailMessage.To.Add(email);
                    mailMessage.Subject = subject;
                    mailMessage.Body = message;
                    mailMessage.IsBodyHtml = true;

                    await smtpClient.SendMailAsync(mailMessage);
                }

                Console.WriteLine("E-posta gönderildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"E-posta gönderirken hata oluştu: {ex.Message}");
            }
        }
    }
}

/*
 using HuzlabBlog.Service.Email.Abstractions;
using Microsoft.Extensions.Options; 
using System.Net;
using System.Net.Mail;

namespace HuzlabBlog.Service.Email.Concrete
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings emailSettings; 

        public EmailSender(IOptions<EmailSettings> emailSettings) 
        {
            this.emailSettings = emailSettings.Value; 
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient(emailSettings.SmtpHost)) 
                {
                    smtpClient.Port = emailSettings.SmtpPort; 
                    smtpClient.Credentials = new NetworkCredential(emailSettings.SmtpUsername, emailSettings.SmtpPassword); 
                    smtpClient.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(emailSettings.SenderEmail); 
                    mailMessage.To.Add(email);
                    mailMessage.Subject = subject;
                    mailMessage.Body = message;
                    mailMessage.IsBodyHtml = true;

                    await smtpClient.SendMailAsync(mailMessage);
                }

                Console.WriteLine("E-posta gönderildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"E-posta gönderirken hata oluştu: {ex.Message}");
            }
        }
    }
}
*/