using System.Net.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace musicbotservice.Services.Mail
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender
    {
        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public AuthMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public Task<HttpResponseMessage> SendEmailAsync(string email, string subject, string message)
        {
            //Plug in your email service here to send an email
            var sendMail = MailgunClient.GetInstance(Options.MailgunDomain, Options.MailgunApiKey);
            return sendMail.SendEmailAsync(email, subject, message);
        }
    }
}
