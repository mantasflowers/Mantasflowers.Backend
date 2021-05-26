using Newtonsoft.Json;
using System;

namespace Mantasflowers.Contracts.ServiceAgents.Common.Templates
{
    public class DateTemplate
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("timezone_type")]
        public int TimezoneType { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
