using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Pingo.CommandLine.ConsoleUtility;

namespace Pingo.CommandLine.ConsoleUtility
{
    public static class ColumnExtensions
    {
        /*
         * usage :
         * 
            var consoleWidth = Console.BufferWidth - 1;
            var minColumnWidth = 14;

            var slimWideSlimColumnWidths = new[] {14, 999, 14};
            var slimWideSlimColumnFlexIds = new[] { 1 };
            var slimWideSlimColumnTruncatedIds = new[] {0, 2};

            slimWideSlimColumnWidths = slimWideSlimColumnWidths.ToFlexWidthColumns(slimWideSlimColumnFlexIds, consoleWidth, minColumnWidth);

            var twoColumnWidths = new[] { 14, 999 };
            var twoColumnFlexIds = new[] { 1 };
            var twoColumnTruncatedIds = new[] {0};

            twoColumnWidths = twoColumnWidths.ToFlexWidthColumns(twoColumnFlexIds, consoleWidth, minColumnWidth);


            string[] complexString = {"Harry" , "Potter"};
            Console.WriteLine(complexString.ToColumnFormat(twoColumnWidths, twoColumnTruncatedIds));
            Console.WriteLine();

            var input = "This is a long sentence with a reallyreallyreallyreallyreallyreallyreallyreallyreallyreallyreallyreallyreally long word in it.";

            complexString = new[] { "HarryHarryHarryHarry", input, "HarryHarryHarryHarry" };
            Console.WriteLine(complexString.ToColumnFormat(slimWideSlimColumnWidths, slimWideSlimColumnTruncatedIds));
            Console.WriteLine();
        
         
            complexString = new[] { "HarryHarryHarryHarry", input, "HarryHarryHarryHarry" };
            Console.WriteLine(complexString.ToColumnFormat(slimWideSlimColumnWidths, twoColumnTruncatedIds));
            Console.WriteLine();
      
         */
        private static readonly int spacer = 2;
        public static IEnumerable<string> ChunksUpTo(this string str, int maxChunkSize)
        {
            var pattern = string.Format(@"(.{{1,{0}}})(?:\s|$)|(.{{{0}}})", maxChunkSize);
            var output = Regex.Split(str, pattern)
                .Where(x => x.Length > 0)
                .ToList();
            return output;
        }

        public static string Truncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "..";
        }

        public static int[] ToFlexWidthColumns(this int[] columnWidths, int[] flexColumnIds, int maxWidth, int minColumnWidth)
        {
            var arrayCount = columnWidths.Count();
            var resultWidths = new int[arrayCount];

            Array.Copy(columnWidths, resultWidths, arrayCount);

            var totalColumnWidths = Enumerable.Sum(columnWidths);
            if (totalColumnWidths > maxWidth)
            {
                // Wanted width exceeds actual width
                int over = totalColumnWidths - maxWidth;
                // Take our pound of flesh from the flexColumns;
                while (over > 0)
                {
                    bool sacrificed = false;
                    foreach (var fid in flexColumnIds)
                    {
                        if (over <= 0)
                            break;
                        if (resultWidths[fid] > minColumnWidth)
                        {
                            sacrificed = true;
                            resultWidths[fid] -= 1;
                            --over;
                        }
                    }
                    if (!sacrificed)
                    {
                        // we sacrificed what we could and still not enough, MinColumnWidth won
                        throw new ArgumentOutOfRangeException("flexColumnIds"
                            , string.Format("we sacrificed what we could and still not enough,Constraint MinColumnWidth:{0} not met", minColumnWidth));
                    }
                }
            }
            else
            {
                var over = maxWidth - totalColumnWidths;
                // we get to give back;
                while (over > 0)
                {
                    foreach (var fid in flexColumnIds)
                    {
                        if (over <= 0)
                            break;
                        resultWidths[fid] += 1;
                        --over;
                    }
                }
            }
            return resultWidths;
        }

        public static string[] ToColumnFormat(this string[] original, int[] columnWidths, int[] truncatedColumns)
        {
            int totalWidth = columnWidths.Sum();
            if (original.Count() != columnWidths.Count())
            {
                throw new ArgumentOutOfRangeException();
            }

            var arrayCount = columnWidths.Count();
            var resultArray = new string[arrayCount];

            Array.Copy(original, resultArray, arrayCount);
            foreach (var tc in truncatedColumns)
            {
                resultArray[tc] = resultArray[tc].Truncate(columnWidths[tc] - (2 + spacer));
            }

            var chunkEnumArray = new IEnumerable<string>[arrayCount];

            var longest = 0;
            for (var index = 0; index < arrayCount; ++index)
            {
                chunkEnumArray[index] = resultArray[index].ChunksUpTo(columnWidths[index] - spacer);
                longest = (chunkEnumArray[index].Count() > longest ? chunkEnumArray[index].Count() : longest);
            }

            var arr = new string[arrayCount][];
            for (var ac = 0; ac < arrayCount; ++ac)
            {
                arr[ac] = new string[longest];
                Array.Copy(chunkEnumArray[ac].ToArray(), arr[ac], chunkEnumArray[ac].Count());
            }

            var arrLines = new string[longest];
            for (var longIndex = 0; longIndex < longest; ++longIndex)
            {
                var resultOut = "";
                for (var ac = 0; ac < arrayCount; ++ac)
                {
                    resultOut += (arr[ac][longIndex] ?? "").PadRight(columnWidths[ac]);
                }
                if (resultOut.Count() > totalWidth)
                {
                    throw new Exception("Got your calculation wrong");
                }
                arrLines[longIndex] = resultOut;
            }
            return arrLines;
        }
    }
}
