using Connect.Common.Utils;
using Newtonsoft.Json;
using System;

namespace Connect.Common.JsonConverters
{
    public class ErrorCodeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = reader.Value != null ? reader.Value.ToString() : string.Empty;

            if (string.IsNullOrEmpty(value))
            {
                return ErrorCode.None;
            }
            else
            {
                return EnumTools.ParseEnum(value, ErrorCode.None);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ErrorCode errorCode = (ErrorCode)value;

            writer.WriteValue(errorCode.ToString());
        }
    }
}