using System;
using System.Linq;
using System.Reflection;

namespace Pingo.CommandLine.ConsoleUtility
{
    public abstract class HelpCommandPage
    {
        public enum ResourceString
        {
            CommandDescription,
            Options,
            CommandArguments,
            FormatUsageString,
            Footer

        }
        private string _command;
        protected HelpCommandPage(string command)
        {
            _command = command;
        }
        protected abstract string FetchString(ResourceString resourceString);
        protected abstract string[][] OptionItemHelpRecords();

        private int[] _columnWidthTemplate;
        private int[] ColumnWidthTemplate
        {
            get
            {
                if (_columnWidthTemplate == null)
                {
                    var initial = new[] { ColumnOneWidth(), 999 };
                    _columnWidthTemplate = initial.ToFlexWidthColumns(ColumnFlexIds, ConsoleWidth(), ColumnOneWidth());
                }
                return _columnWidthTemplate;
            }
        }

        protected abstract int ConsoleWidth();
        private static readonly int[] ColumnFlexIds = { 1 };
        private static readonly int[] ColumTruncatedIds = { 0 };
        protected abstract int ColumnOneWidth();

        public void WriteHelpCommandPage()
        {
            var assembly = Assembly.GetEntryAssembly();
            Console.WriteLine(FetchString(ResourceString.FormatUsageString), assembly.GetName().Name, _command
                , FetchString(ResourceString.CommandArguments), FetchString(ResourceString.Options));
            Console.WriteLine();
            Console.WriteLine(FetchString(ResourceString.CommandDescription));
            Console.WriteLine();
            Console.WriteLine(FetchString(ResourceString.Options) + ":");
            Console.WriteLine();

            var records = OptionItemHelpRecords();
            var arLast = records.Last();
            foreach (var ar in records)
            {
                Console.WriteLine(ar.ToColumnFormat(ColumnWidthTemplate, ColumTruncatedIds));
                if (ar != arLast)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine(FetchString(ResourceString.Footer));
        }

    }
}