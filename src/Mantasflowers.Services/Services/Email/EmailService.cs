using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Mantasflowers.Services.Services.Exceptions;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Mantasflowers.Services.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly ISendGridClient _sendGridClient;
        private readonly SendgridConfiguration _sendGridConfig;

        public EmailService(ISendGridClient sendGridClient, SendgridConfiguration sendGridConfig)
        {
            _sendGridClient = sendGridClient;
            _sendGridConfig = sendGridConfig;
        }

        public async Task SendEmailAsync(
            DateTime purchaseDate,
            string clientFullName,
            string clientEmail,
            string orderNumber,
            string orderUrl)
        {
            var emailHtmlTemplate = new StringBuilder(
                await File.ReadAllTextAsync(_sendGridConfig.EmailTemplatePath));
            var emailHtml = emailHtmlTemplate
                .Replace("[[purchase_timestamp]]", purchaseDate.ToString())
                .Replace("[[seller]]", "Mantasflowers")
                .Replace("[[customer_fullname]]", clientFullName)
                .Replace("[[customer_email]]", clientEmail)
                .Replace("[[order_id]]", orderNumber)
                .Replace("[[purchase_link]]", orderUrl)
                .ToString();
        
            var msg = new SendGridMessage
            {
                From = new EmailAddress(_sendGridConfig.From, _sendGridConfig.FromName),
                Subject = $"Order {orderNumber} completion",
                HtmlContent = emailHtml
            };
            msg.AddTo(new EmailAddress(clientEmail, clientFullName));
        
            var response = await _sendGridClient.SendEmailAsync(msg);

            if (response.StatusCode != HttpStatusCode.Accepted)
            {
                throw new EmailSendFailedException($"Sendgrind failed to send the email through to {clientEmail}");
            }
        }
    }
}