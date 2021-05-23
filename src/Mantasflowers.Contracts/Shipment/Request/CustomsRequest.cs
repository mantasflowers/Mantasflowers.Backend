using System.Collections.Generic;

namespace Mantasflowers.Contracts.Shipment.Request
{
    public class CustomsRequest
    {
        public string DocType { get; set; }

        public string Reason { get; set; }

        public string SenderName { get; set; }

        public string SenderTaxReference { get; set; }

        public string RecipientName { get; set; }

        public string RecipientTaxReference { get; set; }

        public string CountryOfManufacture { get; set; }

        public IList<ItemRequest> Items { get; set; }
    }
}
