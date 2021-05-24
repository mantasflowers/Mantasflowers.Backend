using Mantasflowers.Contracts.Shipment.Request;
using System.Collections.Generic;

namespace Mantasflowers.Contracts.Common.Templates
{
    public abstract class QuotesTemplate
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public decimal GoodsValue { get; set; }

        public IList<BoxRequest> Boxes { get; set; }

        public SenderRequest Sender { get; set; }

        public RecipientRequest Recipient { get; set; }
    }
}
