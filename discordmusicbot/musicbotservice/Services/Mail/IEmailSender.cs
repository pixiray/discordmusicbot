using System.Net.Http;
using System.Threading.Tasks;

namespace musicbotservice.Services.Mail
{
    public interface IEmailSender
    {
        //Simple Mail implementation for ASP.net Core
        Task<HttpResponseMessage> SendEmailAsync(string email, string subject, string message);
    }
}
