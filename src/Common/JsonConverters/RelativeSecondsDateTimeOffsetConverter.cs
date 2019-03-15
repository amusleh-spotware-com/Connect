using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Globalization;

namespace Connect.Common.JsonConverters
{
    public class RelativeSecondsDateTimeOffsetConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long) || objectType == typeof(long?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long? seconds = (long?)reader.Value;

            if (seconds.HasValue)
            {
                return DateTimeOffset.UtcNow.AddSeconds(seconds.Value);
            }
            else
            {
                return DateTimeOffset.UtcNow;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTimeOffset? time = (DateTimeOffset?)value;

            if (time.HasValue)
            {
                TimeSpan timeDiff = time.Value - DateTimeOffset.UtcNow;

                writer.WriteValue(timeDiff.TotalMilliseconds);
            }
            else
            {
                writer.WriteValue(0);
            }
        }
    }
}
