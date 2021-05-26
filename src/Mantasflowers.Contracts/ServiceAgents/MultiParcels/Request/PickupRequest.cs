using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mantasflowers.Contracts.ServiceAgents.MultiParcels.Request
{
    public class PickupRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("packages")]
        public int Packages { get; set; }

        [JsonProperty("package_sizes")]
        public IList<string> PackageSizes { get; set; }

        [JsonProperty("weight")]
        public decimal Weight { get; set; }
    }
}
