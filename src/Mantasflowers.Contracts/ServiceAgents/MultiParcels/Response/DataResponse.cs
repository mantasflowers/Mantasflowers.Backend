using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.MultiParcels.Response
{
    public class DataResponse
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }

        [JsonProperty("manifest")]
        public int Manifest { get; set; }

        [JsonProperty("pickup_type_code")]
        public string PickupTypeCode { get; set; }

        [JsonProperty("delivery_type_code")]
        public string DeliveryTypeCode { get; set; }

        [JsonProperty("courier_code")]
        public string CourierCode { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("packages")]
        public int Packages { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("created_at")]
        public CreatedAtResponse CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public CreatedAtResponse UpdatedAt { get; set; }
    }
}
