using System;

namespace Pingo.CommandLine.Enum
{
    public static class EnumExtensions
    {
        public static string ToBangEnum<T>(this T type) where T : Type
        {
            string enumValues = "";
            foreach (var value in System.Enum.GetValues(type))
            {
                enumValues += (value.ToString()) + "|";
            }
            enumValues = enumValues.TrimEnd('|');
            return enumValues;
        }

        public static string ToFirstEnum<T>(this T type) where T : Type
        {
            var enumArrays = System.Enum.GetValues(type);
            var first = enumArrays.GetValue(0);
            return first.ToString();
        }
    }
}
