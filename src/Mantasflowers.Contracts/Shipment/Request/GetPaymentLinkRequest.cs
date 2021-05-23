using System.Collections.Generic;

namespace Mantasflowers.Contracts.Shipment.Request
{
    public class GetPaymentLinkRequest
    {
        public IList<string> ShipmentIds { get; set; }
    }
}
