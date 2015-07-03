using System;
using System.Linq;
using Pingo.CommandLine.String;

namespace Pingo.CommandLine.ConsoleUtility
{
    public abstract class Writer
    {
        public enum StringResources
        {
            FormatTitleLine
        }

        public abstract string AcquireString(StringResources id);

        public void WriteTitleBlock(string name)
        {
            var titleLine = string.Format(AcquireString(StringResources.FormatTitleLine), name);
            var breakerLine = new string('-', titleLine.Count());

            Console.WriteLine(breakerLine);
            Console.WriteLine(titleLine);
            Console.WriteLine(breakerLine);
        }

        public static void WriteIndent(string content, int level)
        {
            var indentedContent = HelpStringHelpers.GetIndentString(level) + content.Replace(Environment.NewLine, Environment.NewLine + HelpStringHelpers.GetIndentString(level));
            Console.WriteLine(indentedContent);

        }
    }
}
