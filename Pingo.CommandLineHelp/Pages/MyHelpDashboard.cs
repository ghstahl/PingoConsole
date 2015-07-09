using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Pingo.CommandLine.ConsoleUtility;
using Pingo.CommandLineHelp.Resources;

namespace Pingo.CommandLineHelp.Pages
{
    public class MyHelpDashboard : ColumnConsolePage
    {
        private SortedList<string, Pingo.CommandLine.Contracts.Help.ICommandHelp> _commandHelps;
        private Pingo.CommandLine.Contracts.Help.IHelpResource _helpResource;
        public MyHelpDashboard(
            SortedList<string, Pingo.CommandLine.Contracts.Help.ICommandHelp> commandHelps,
            Pingo.CommandLine.Contracts.Help.IHelpResource helpResource,
            int[] columnWidthTemplate,
            int[] truncatedColumnIds)
            : base(columnWidthTemplate, truncatedColumnIds)
        {
            _commandHelps = commandHelps;
            _helpResource = helpResource;
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
                case ResourceString.Header:
                    if (_helpResource != null)
                    {
                        result = _helpResource.Header;
                    }
                    break;

                case ResourceString.Footer:
                    if (_helpResource != null)
                    {
                        result = _helpResource.Footer;
                    }
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