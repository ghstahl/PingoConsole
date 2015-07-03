using System.Reflection;
using Pingo.CommandLine.ConsoleUtility;
using Pingo.CommandLine.Contracts.Help;
using Pingo.CommandLineHelp.Resources;

namespace Pingo.CommandLineHelp.Pages
{
    public class MyCommandHelpPage : ColumnConsolePage
    {
        private ICommandHelp _commandHelp;
        public MyCommandHelpPage(
            ICommandHelp commandHelp,
            int[] columnWidthTemplate,
            int[] truncatedColumnIds)
            : base(columnWidthTemplate, truncatedColumnIds)
        {
            _commandHelp = commandHelp;
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
                
                case ResourceString.Footer:
                    result = Common.Footer;
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
                IOptionHelp dds = (IOptionHelp) _commandHelp.Options.GetByIndex(ac);

                arr[ac][0] = "";
                arr[ac][1] = dds.Name;
                arr[ac][2] = dds.Description;
                 
            }
            return arr;
        }
    }
}