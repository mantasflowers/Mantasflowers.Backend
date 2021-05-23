using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Request
{
    public class ItemRequest
    {
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("value_per_unit")]
        public decimal ValuePerUnit { get; set; }
    }
}
