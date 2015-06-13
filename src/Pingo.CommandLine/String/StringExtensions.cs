using System;
using System.Collections.Generic;

namespace Pingo.CommandLine.String
{
    public static class StringExtensions
    {
        public static string ToSeparator(this IEnumerable<string> stringArray, char separator) 
        {

            string values = "";
            foreach (var value in stringArray)
            {
                values += value + separator;
            }
            values = values.TrimEnd(separator);
            return values;
        }

    }
}
