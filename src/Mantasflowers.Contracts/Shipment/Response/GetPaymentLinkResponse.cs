using System.Collections.Generic;

namespace Mantasflowers.Contracts.Shipment.Response
{
    public class GetPaymentLinkResponse
    {
        public string OrderId { get; set; }

        public string Url { get; set; }

        public IList<string> Shipments { get; set; }
    }
}
