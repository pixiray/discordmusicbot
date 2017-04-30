﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicbotservice.Services.Mail
{
    public class MailgunApiEmailSettings
    {
        public string ApiKey { get; set; }

        public string BaseUri { get; set; }

        public string RequestUri { get; set; }

        public string From { get; set; }
    }
}
