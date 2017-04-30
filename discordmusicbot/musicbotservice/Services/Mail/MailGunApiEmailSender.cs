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
    public class MailGunApiEmailSender : IEmailSender
    {
        //Identifys connection type to Mailgun Server
        public const string ConnectionType = "api";

        //Identify the external E-mail Provider
        public const string Provider = "Mailgun";

        private readonly MailgunApiEmailSettings _apiEmailConfig;

        /// <summary>
        /// Accessor for the configuartion to send mail via Mailgun API
        /// </summary>
        public MailgunApiEmailSettings EmailSettings => _apiEmailConfig;

        #region ctor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MailGunApiEmailSender(IOptions<MailgunApiEmailSettings> apiEmailConfig)
        {
            _apiEmailConfig = apiEmailConfig.Value;
        }

        #endregion

        /// <summary>
        /// Interface Implementation of IEmailSender
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            string apiKey = EmailSettings.ApiKey;

            string baseUri = EmailSettings.BaseUri;

            string requestUri = EmailSettings.RequestUri;

            string token = HttpBasicAuthHeader("api", apiKey);

            FormUrlEncodedContent emailContent = HttpContent(email,
                subject,
                message
            );

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUri);

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", token);

                HttpResponseMessage response = await client.PostAsync(requestUri, emailContent).ConfigureAwait(false);

                if (false == response.IsSuccessStatusCode)
                {

                    string errMsg = String.Format(
                        "Failed to send mail to {0} via {1} {2} due to\n{3}.",
                        email,
                        Provider,
                        ConnectionType,
                        response.ToString()
                    );

                    throw new HttpRequestException(errMsg);

                }

            }

        }

        // 
        // Put together the basic authentication header for MailGun 
        // Rest API (see https://documentation.mailgun.com/quickstart-sending.html#send-via-api).
        // 
        protected string HttpBasicAuthHeader(
            string tokenName,
            string tokenValue
        )
        {

            string tokenString = string.Format(
                "{0}:{1}",
                tokenName,
                tokenValue
            );

            byte[] bytes = Encoding.UTF8.GetBytes(tokenString);

            string authHeader = Convert.ToBase64String(bytes);

            return authHeader;

        }

        // 
        // Put together the core elements for the email for MailGun.
        // 
        // For a list of valid fields, please refer to MailGun document 
        // (see https://documentation.mailgun.com/api-sending.html#sending).
        //
        protected FormUrlEncodedContent HttpContent(
            string recipient,
            string subject,
            string message
        )
        {

            string sender = EmailSettings.From;

            var emailSender = new KeyValuePair<string, string>("from", sender);

            var emailRecipient =
                new KeyValuePair<string, string>("to", recipient);

            var emailSubject =
                new KeyValuePair<string, string>("subject", subject);

            var emailBody =
                new KeyValuePair<string, string>("text", message);

            List<KeyValuePair<string, string>> content =
                new List<KeyValuePair<string, string>>();

            content.Add(emailSender);

            content.Add(emailRecipient);

            content.Add(emailSubject);

            content.Add(emailBody);

            FormUrlEncodedContent urlEncodedContent =
                new FormUrlEncodedContent(content);

            return urlEncodedContent;

        }
    }
}
