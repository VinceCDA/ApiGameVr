using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ApiGameVr.Domain.Helper
{
    public class EnumHelper
    {
        public static string GetEnumValue<T>(T enumValue) where T : Enum
        {
            var type = enumValue.GetType();
            var memInfo = type.GetMember(enumValue.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
            string? textEnum = ((EnumMemberAttribute)attributes[0]).Value;
            if (textEnum != null )
            {
                return textEnum;
            }
            throw new ArgumentException($"Unknown value: {enumValue}");
        }
        public static T GetEnumFromString<T>(string value) where T : Enum
        {
            var type = typeof(T);
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute && attribute.Value == value)
                {
                    T? num = (T?)field.GetValue(null);
                    if (num != null)
                    {
                        return num;
                    }
                    throw new ArgumentException($"Unknown value: {value}");
                }
            }
            throw new ArgumentException($"Unknown value: {value}");
        }
    }
}
