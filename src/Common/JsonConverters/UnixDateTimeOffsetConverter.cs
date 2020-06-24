using Newtonsoft.Json;
using System;

namespace Connect.Common.JsonConverters
{
    public class UnixDateTimeOffsetConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long) || objectType == typeof(long?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long? milliseconds = (long?)reader.Value;

            if (milliseconds.HasValue)
            {
                return DateTimeOffset.FromUnixTimeMilliseconds(milliseconds.Value);
            }
            else
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTimeOffset? time = (DateTimeOffset?)value;

            if (time.HasValue)
            {
                writer.WriteValue(time.Value.ToUnixTimeMilliseconds());
            }
            else
            {
                writer.WriteValue(time);
            }
        }
    }
}