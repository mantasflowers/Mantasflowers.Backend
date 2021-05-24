using Mantasflowers.Contracts.ServiceAgents.Common.Templates;
using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Request
{
    public class CreateShipmentRequest : QuotesTemplate
    {
        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("goods_description")]
        public string GoodsDescription { get; set; }

        [JsonProperty("delivery_notes")]
        public string DeliveryNotes { get; set; }

        [JsonProperty("collection_date")]
        public string CollectionDate { get; set; }

        [JsonProperty("customs")]
        public CustomsRequest Customs { get; set; }
    }
}
