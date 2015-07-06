using System;
using System.Linq;

namespace Pingo.CommandLine.ConsoleUtility
{
    public abstract class ColumnConsolePage
    {

        protected int[] TruncatedColumnIds { get; private set; }
        protected int[] ColumnWidthTemplate { get; private set; }

        protected int PageWidth { get; private set; }
        protected ColumnConsolePage(int[] columnWidthTemplate, int[] truncatedColumnIds)
        {
            ColumnWidthTemplate = columnWidthTemplate;
            TruncatedColumnIds = truncatedColumnIds;
            PageWidth = columnWidthTemplate.Sum();
        }
        public enum ResourceString
        {
            MainTitlePanel,
            SecondaryTitlePanel,
            ColumnBlockTitle,
            Footer
        }
        protected abstract string FetchString(ResourceString resourceString);

        protected abstract string[][] CommandItemHelpRecords();
        private void Write(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;
            var chunkArray = value.ChunksUpTo(PageWidth);
            foreach (var item in chunkArray)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        public void WritePage()
        {
            Write(FetchString(ResourceString.MainTitlePanel));
            Write(FetchString(ResourceString.SecondaryTitlePanel));
            WriteColumItems();
            Write(FetchString(ResourceString.Footer));
        }
        private void WriteColumItems()
        {
            Write(FetchString(ResourceString.ColumnBlockTitle));
            var records = CommandItemHelpRecords();
            if (records == null || !records.Any())
                return;
            foreach (var ar in records)
            {
                var lines = ar.ToColumnFormat(ColumnWidthTemplate, TruncatedColumnIds);
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine();
         //       Console.Write(ar.ToColumnFormat(ColumnWidthTemplate, TruncatedColumnIds));
            }
          //  Console.WriteLine();
        }
    }
}
