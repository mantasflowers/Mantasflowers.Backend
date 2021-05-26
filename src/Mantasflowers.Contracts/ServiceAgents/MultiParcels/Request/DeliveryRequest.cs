using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.MultiParcels.Request
{
    public class DeliveryRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("courier")]
        public string Courier { get; set; }
    }
}
