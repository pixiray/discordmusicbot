namespace musicbotservice.Services.Mail
{
    internal class MailgunMail
    {
        public string To { get; set; }
        public string ToName { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }
    }
}