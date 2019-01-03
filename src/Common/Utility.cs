using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace Connect.Common
{
    public static class Utility
    {
        public static string GetEnumDescription(object enumObject)
        {
            FieldInfo field = enumObject.GetType().GetField(enumObject.ToString());

            DescriptionAttribute descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>(false);

            if (descriptionAttribute != null && !string.IsNullOrEmpty(descriptionAttribute.Description))
            {
                return descriptionAttribute.Description;
            }

            return enumObject.ToString();
        }


        public static TEnum ParseEnum<TEnum>(string text, TEnum defaultValue, bool ignoreCase = true) where TEnum : struct
        {
            TEnum result = defaultValue;

            if (!string.IsNullOrEmpty(text))
            {
                Enum.TryParse(text, ignoreCase, out result);
            }

            return result;
        }
    }
}
