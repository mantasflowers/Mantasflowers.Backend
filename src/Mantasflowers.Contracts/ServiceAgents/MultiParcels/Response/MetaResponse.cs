using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mantasflowers.Contracts.ServiceAgents.MultiParcels.Response
{
    public class MetaResponse
    {
        [JsonProperty("include")]
        public IList<string> Include { get; set; }

        [JsonProperty("custom")]
        public IList<string> Custom { get; set; }
    }
}
