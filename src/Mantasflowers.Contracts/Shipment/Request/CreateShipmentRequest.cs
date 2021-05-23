using Mantasflowers.Contracts.Common.Templates;

namespace Mantasflowers.Contracts.Shipment.Request
{
    public class CreateShipmentRequest : QuotesTemplate
    {
        public string Service { get; set; }

        public string GoodsDescription { get; set; }

        public string DeliveryNotes { get; set; }

        public string CollectionDate { get; set; }

        public CustomsRequest Customs { get; set; }
    }
}
