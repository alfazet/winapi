using System;
using System.ComponentModel;
using System.Reflection;

namespace ContactsApp.Domain.Shared
{
    public static class EnumExtensionMethod
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
                return string.Empty;
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
