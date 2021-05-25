using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Email.Request;
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

        public async Task SendEmailAsync(SendEmailRequest request)
        {
            var emailHtmlTemplate = new StringBuilder(
                await File.ReadAllTextAsync(_sendGridConfig.EmailTemplatePath));
            var emailHtml = emailHtmlTemplate
                .Replace("[[purchase_timestamp]]", request.PurchaseDate.ToString())
                .Replace("[[seller]]", "Mantasflowers")
                .Replace("[[customer_fullname]]", request.ClientFullName)
                .Replace("[[customer_email]]", request.ClientEmail)
                .Replace("[[order_id]]", request.OrderNumber)
                .Replace("[[purchase_link]]", request.OrderUrl)
                .ToString();

            var msg = new SendGridMessage
            {
                From = new EmailAddress(_sendGridConfig.From, _sendGridConfig.FromName),
                Subject = $"Order {request.OrderNumber} completion",
                HtmlContent = emailHtml
            };
            msg.AddTo(new EmailAddress(request.ClientEmail, request.ClientFullName));

            var response = await _sendGridClient.SendEmailAsync(msg);

            if (response.StatusCode != HttpStatusCode.Accepted)
            {
                throw new EmailSendFailedException($"Sendgrind failed to send the email through to {request.ClientEmail}");
            }
        }
    }
}