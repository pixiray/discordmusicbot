using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace musicbotservice.Services.Mail
{
    /// <summary>
    /// This class is the implementation for Sending Emails via MailGun
    /// </summary>
    public class MailgunClient : IEmailSender
    {
        private static MailgunClient _client;
        //private const string BaseUrl = @"https://api.mailgun.net/v2";

        public string Domain { get; set; }
        public string Secret { get; set; }

        private MailgunClient(string domain, string apikey)
        {
            Domain = domain;
            Secret = apikey;
        }

        public static MailgunClient GetInstance(string user, string secret)
        {
            if (_client == null)
            {
                _client = new MailgunClient(user, secret);
            }
            return _client;
        }

        private AuthenticationHeaderValue CreateAuthenticationHeader()
        {
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("api" + ":" + Secret)));
        }

        public async Task<HttpResponseMessage> SendEmailAsync(string email, string subject, string message)
        {
            using (var httpClient = new HttpClient())
            {
                //httpClient.BaseAddress = new Uri(BaseUrl);
                httpClient.DefaultRequestHeaders.Authorization = CreateAuthenticationHeader();

                //HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, $"{Domain}/messages");

                var mailform = new Dictionary<string, string>
                {
                    {"from", "Team Pixiray <support@pixiray.io>"},
                    {"to", email},
                    {"subject", subject},
                    {"html", message}
                };

                var response = await httpClient.PostAsync("https://api.mailgun.net/v2/" + Domain + "/messages", new FormUrlEncodedContent(mailform));
                return response;
            }
        }
    }

}
