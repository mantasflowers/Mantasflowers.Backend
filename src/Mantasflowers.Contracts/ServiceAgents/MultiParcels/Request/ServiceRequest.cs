using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.MultiParcels.Request
{
    public class ServiceRequest
    {
        [JsonProperty("enabled")]
        public int Enabled { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
