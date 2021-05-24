using Mantasflowers.Contracts.ServiceAgents.Common.Converters;
using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Response
{
    public class CancelShipmentResponse
    {
        [JsonProperty("ShipmentId")]
        public string ShipmentId { get; set; }

        [JsonProperty("ShipmentCancelled"), JsonConverter(typeof(BooleanJsonConverter))]
        public bool ShipmentCancelled { get; set; }
    }
}
