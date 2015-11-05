using System;
using Newtonsoft.Json;

namespace Anothar.OpenTripPlannerClient
{
    internal class TimeSpanSecondsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var ts = value as TimeSpan?;
            if (ts == null)
                return;
            serializer.Serialize(writer, (int)ts.Value.TotalSeconds);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = serializer.Deserialize<int>(reader);
            return TimeSpan.FromSeconds(value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan) || objectType == typeof(TimeSpan?);
        }
    }
}
