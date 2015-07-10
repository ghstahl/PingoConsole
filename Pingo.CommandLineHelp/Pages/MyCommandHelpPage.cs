using System.Reflection;
using Pingo.CommandLine.ConsoleUtility;
using Pingo.CommandLineHelp.Resources;

namespace Pingo.CommandLineHelp.Pages
{
    public class MyCommandHelpPage : ColumnConsolePage
    {
        private Pingo.CommandLine.Contracts.Help.ICommandHelp _commandHelp;
        private Pingo.CommandLine.Contracts.Help.IHelpResource _helpResource;
        public MyCommandHelpPage(
            Pingo.CommandLine.Contracts.Help.ICommandHelp commandHelp,
            Pingo.CommandLine.Contracts.Help.IHelpResource helpResource,
            int[] columnWidthTemplate,
            int[] truncatedColumnIds)
            : base(columnWidthTemplate, truncatedColumnIds)
        {
            _commandHelp = commandHelp;
            _helpResource = helpResource;
        }

        protected override string FetchString(ResourceString resourceString)
        {
            var assembly = Assembly.GetEntryAssembly();
            string result = null;
            switch (resourceString)
            {
                case ResourceString.MainTitlePanel:
                    result = string.Format(Common.Format_UsageFormat
                        , assembly.GetName().Name, _commandHelp.Name, _commandHelp.Usage);
                    break;

                case ResourceString.ColumnBlockTitle:
                    result = _commandHelp.Options == null ? Common.Options_None : Common.Options;
                    break;

                case ResourceString.SecondaryTitlePanel:
                    result = _commandHelp.Detailed;
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
                        result =  _helpResource.Footer;
                    }
                    break;
            }
            return result;
        }

        protected override string[][] CommandItemHelpRecords()
        {
            if (_commandHelp.Options == null)
                return null;

            var count = _commandHelp.Options.Count;
            var arr = new string[count][];

         
            for (var ac = 0; ac < count; ++ac)
            {
                arr[ac] = new string[3];
                var dds = (Pingo.CommandLine.Contracts.Help.IOptionHelp)_commandHelp.Options.GetByIndex(ac);

                arr[ac][0] = "";
                arr[ac][1] = dds.Name;
                arr[ac][2] = dds.Description;
                 
            }
            return arr;
        }
    }
}