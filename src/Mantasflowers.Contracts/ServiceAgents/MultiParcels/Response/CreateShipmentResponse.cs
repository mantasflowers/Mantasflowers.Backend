using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.MultiParcels.Response
{
    public class CreateShipmentResponse
    {
        [JsonProperty("data")]
        public DataResponse Data { get; set; }

        [JsonProperty("meta")]
        public MetaResponse Meta { get; set; }
    }
}
