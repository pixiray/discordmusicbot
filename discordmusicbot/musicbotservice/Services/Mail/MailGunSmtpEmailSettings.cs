using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicbotservice.Services.Mail
{
    public class MailGunSmtpEmailSettings
    {

            public string SmtpHost { get; set; }

            public int SmtpPort { get; set; }

            public string SmtpLogin { get; set; }

            public string SmtpPassword { get; set; }

            public string SenderName { get; set; }

            public string From { get; set; }

    }
}
