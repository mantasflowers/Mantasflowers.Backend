using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Request
{
    public class GetTrackingEventsRequest
    {
        [JsonProperty("ShipmentId")]
        public string ShipmentId { get; set; }
    }
}
