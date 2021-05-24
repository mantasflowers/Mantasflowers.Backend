using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Request
{
    public class BoxRequest
    {
        /// <summary>
        /// In centimeters
        /// </summary>
        [JsonProperty("length")]
        public decimal Length { get; set; }

        /// <summary>
        /// In centimeters
        /// </summary>
        [JsonProperty("width")]
        public decimal Width { get; set; }

        /// <summary>
        /// In centimeters
        /// </summary>
        [JsonProperty("height")]
        public decimal Height { get; set; }

        /// <summary>
        /// In kilograms
        /// </summary>
        [JsonProperty("weight")]
        public decimal Weight { get; set; }
    }
}
