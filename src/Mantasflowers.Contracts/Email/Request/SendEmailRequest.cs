using System;

namespace Mantasflowers.Contracts.Email.Request
{
    public class SendEmailRequest
    {
        public DateTime PurchaseDate { get; set; }

        public string ClientFullName { get; set; }

        public string ClientEmail { get; set; }

        public string OrderNumber { get; set; }

        public string OrderUrl { get; set; }
    }
}
