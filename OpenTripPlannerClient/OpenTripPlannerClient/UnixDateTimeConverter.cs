using System;
using Newtonsoft.Json;

namespace Anothar.OpenTripPlannerClient
{
    internal class UnixDateTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var ts = value as DateTime?;
            if (ts == null)
                return;
            serializer.Serialize(writer,UnixTime.FromDateTime(ts.Value));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = serializer.Deserialize<long>(reader);
            return UnixTime.ToDateTime(value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }
    }
}
