using System.Collections.Generic;

namespace Pingo.CommandLineHelp.Pages
{
    public static class UsefulColumnWidthExstension
    {
        public static int LongestNameWidth(this Pingo.CommandLine.Contracts.Help.ICommandHelp commandHelp)
        {
            var columnn2Width = 0;
            if (commandHelp != null && commandHelp.Options != null)
            {
                var count = commandHelp.Options.Count;
                for (var ac = 0; ac < count; ++ac)
                {
                    var dds = (Pingo.CommandLine.Contracts.Help.IOptionHelp)commandHelp.Options.GetByIndex(ac);
                    columnn2Width = (columnn2Width > dds.Name.Length) ? columnn2Width : dds.Name.Length;
                }
            }
            return columnn2Width;
        }

        public static int LongestNameWidth(this SortedList<string, Pingo.CommandLine.Contracts.Help.ICommandHelp> sortedList)
        {
            var column2Width = 0;
            foreach (var item in sortedList)
            {
                column2Width = (column2Width > item.Value.Name.Length)
                    ? column2Width
                    : item.Value.Name.Length;

            }
            return column2Width;
        }
    }
}