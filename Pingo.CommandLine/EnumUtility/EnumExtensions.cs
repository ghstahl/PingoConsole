using System;

namespace Pingo.CommandLine.EnumUtility
{
    public static class EnumExtensions
    {
        public static string ToSeparatorEnum<T>(this T type, char separator) where T : Type
        {
            type.ValidateIsEnum();
            string enumValues = "";
            foreach (var value in System.Enum.GetValues(type))
            {
                enumValues += (value.ToString()) + separator;
            }
            enumValues = enumValues.TrimEnd(separator);
            return enumValues;
        }

        public static void ValidateIsEnum(this Type type) 
        {
            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

        }
        public static object FirstEnum<T>(this T type) where T : Type
        {
            type.ValidateIsEnum();
            var enumArrays = System.Enum.GetValues(type);
            var first = enumArrays.GetValue(0);
            return first;
        }
    }
}
