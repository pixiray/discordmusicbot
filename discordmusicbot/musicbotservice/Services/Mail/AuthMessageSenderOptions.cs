using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicbotservice.Services.Mail
{
    public class AuthMessageSenderOptions
    {
        public string MailgunApiKey { get; set; }
        public string MailgunDomain { get; set; }
        public string SID { get; set; }
        public string AuthToken { get; set; }
        public string SendNumber { get; set; }
    }
}
