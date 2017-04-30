using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicbotservice.Services.Mail
{
    public interface IEmailSender
    {
        //Simple Mail implementation for ASP.net Core
        Task SendEmailAsync(string email, string subject, string message);
    }
}
