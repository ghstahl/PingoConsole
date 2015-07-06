using System;
using System.Linq;
using System.Reflection;

namespace Pingo.CommandLine.ConsoleUtility
{
    public abstract class HelpDashBoard
    {
        public enum ResourceString
        {
            FormatHeaderString,
            AvailableCommands,
            Footer
        }
        protected abstract string FetchString(ResourceString resourceString);
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
        private static readonly int[] ColumnFlexIds = { 1 };
        private static readonly int[] ColumTruncatedIds = { 0 };

        protected abstract int ColumnOneWidth();
        protected abstract int ConsoleWidth();

        protected abstract string[][] CommandItemHelpRecords();
        private void WriteHeader()
        {
            var assembly = Assembly.GetEntryAssembly();
            Console.WriteLine(FetchString(ResourceString.FormatHeaderString), assembly.GetName().Name, assembly.GetName().Version);
        }
        private void WriteFooter()
        {
            Console.WriteLine(FetchString(ResourceString.Footer));

        }
        public void WriteHelpDashboard()
        {
            WriteHeader();
            Console.WriteLine();

            Console.WriteLine(FetchString(ResourceString.AvailableCommands));
            Console.WriteLine();

            WriteCommandHelpDashboardItems();
            Console.WriteLine();
            WriteFooter();
        }
        private void WriteCommandHelpDashboardItems()
        {
            var records = CommandItemHelpRecords();
            var arLast = records.Last();
            foreach (var ar in records)
            {
                Console.WriteLine(ar.ToColumnFormat(ColumnWidthTemplate, ColumTruncatedIds));
                if (ar != arLast)
                {
                    Console.WriteLine();
                }
            }
        }

    }
}