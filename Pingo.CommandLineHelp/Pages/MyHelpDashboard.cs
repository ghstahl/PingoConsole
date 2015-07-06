using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Pingo.CommandLine.ConsoleUtility;
using Pingo.CommandLine.Contracts.Command;
using Pingo.CommandLine.Contracts.Help;
using Pingo.CommandLineHelp.Resources;

namespace Pingo.CommandLineHelp.Pages
{
    public class MyHelpDashboard : ColumnConsolePage
    {
        private SortedList<string, ICommandHelp> _commandHelps;

        public MyHelpDashboard(
            SortedList<string, ICommandHelp> commandHelps,
            int[] columnWidthTemplate,
            int[] truncatedColumnIds)
            : base(columnWidthTemplate, truncatedColumnIds)
        {
            _commandHelps = commandHelps;
        }

        protected override string FetchString(ResourceString resourceString)
        {
            string result = null;
            switch (resourceString)
            {
                case ResourceString.MainTitlePanel:
                    var assembly = Assembly.GetEntryAssembly();
                    result = string.Format(Common.Format_HeaderString
                        , assembly.GetName().Name, assembly.GetName().Version);
                    break;
                case ResourceString.Footer:
                    result = Common.Footer;
                    break;
                case ResourceString.ColumnBlockTitle:
                    result = Common.AvailableCommands;
                    break;
            }
            return result;
        }

        protected override string[][] CommandItemHelpRecords()
        {
            var helpArray = _commandHelps.ToArray();
            var count = _commandHelps.Count();
            var arr = new string[count][];
            for (var ac = 0; ac < count; ++ac)
            {
                arr[ac] = new string[this.ColumnWidthTemplate.Count()];
                arr[ac][0] = "";
                arr[ac][1] = helpArray[ac].Value.Name;
                arr[ac][2] = helpArray[ac].Value.Description;
            }
            return arr;
        }
    }
}