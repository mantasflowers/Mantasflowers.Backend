using Newtonsoft.Json;
using System;

namespace Mantasflowers.Contracts.ServiceAgents.Common.Converters
{
    public class BooleanJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString().ToLower().Trim() switch
            {
                "true" or "yes" or "y" or "1" => true,
                "false" or "no" or "n" or "0" => false,
                _ => new JsonSerializer().Deserialize(reader, objectType),
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
}
