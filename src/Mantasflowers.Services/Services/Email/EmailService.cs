using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Email.Request;
using Mantasflowers.Services.Services.Exceptions;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;

namespace Mantasflowers.Services.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly ISendGridClient _sendGridClient;
        private readonly SendgridConfiguration _sendGridConfig;
        private readonly ILogger _logger;

        public EmailService(
            ISendGridClient sendGridClient,
            SendgridConfiguration sendGridConfig,
            ILogger logger)
        {
            _sendGridClient = sendGridClient;
            _sendGridConfig = sendGridConfig;
            _logger = logger;
        }

        public async Task SendEmailAsync(SendEmailRequest request)
        {
            if (string.IsNullOrWhiteSpace(_sendGridConfig.ApiKey) && _sendGridConfig.CanSkipIfNoApiKey)
            {
                _logger.Warning("Skipping email sending. Api KEY not found...");
                return;
            }

            var emailHtmlTemplate = new StringBuilder(
                await File.ReadAllTextAsync(_sendGridConfig.EmailTemplatePath));
            var emailHtml = emailHtmlTemplate
                .Replace("[[purchase_timestamp]]", request.PurchaseDate.ToString())
                .Replace("[[seller]]", "Mantasflowers")
                .Replace("[[customer_fullname]]", request.ClientFullName)
                .Replace("[[customer_email]]", request.ClientEmail)
                .Replace("[[order_id]]", request.OrderNumber)
                .Replace("[[purchase_link]]", _sendGridConfig.OrderUrl + request.OrderPassword)
                .ToString();

            var msg = new SendGridMessage
            {
                From = new EmailAddress(_sendGridConfig.SenderEmail, _sendGridConfig.FromName),
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