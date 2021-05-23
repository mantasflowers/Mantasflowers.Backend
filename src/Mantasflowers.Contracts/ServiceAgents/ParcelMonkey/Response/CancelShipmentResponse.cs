using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Response
{
    public class CancelShipmentResponse
    {
        [JsonProperty("ShipmentId")]
        public string ShipmentId { get; set; }

        [JsonProperty("ShipmentCancelled")]
        public string ShipmentCancelled { get; set; }
    }
}
