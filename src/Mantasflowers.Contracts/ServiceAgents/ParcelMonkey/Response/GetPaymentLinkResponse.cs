using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Response
{
    public class GetPaymentLinkResponse
    {
        [JsonProperty("OrderId")]
        public string OrderId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("Shipments")]
        public IList<string> Shipments { get; set; }
    }
}
