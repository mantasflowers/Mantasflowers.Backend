using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Response
{
    public class CreateShipmentResponse
    {
        [JsonProperty("ShipmentId")]
        public int ShipmentId { get; set; }

        [JsonProperty("label_url")]
        public string LabelUrl { get; set; }

        [JsonProperty("tracking_url")]
        public string TrackingUrl { get; set; }
    }
}
