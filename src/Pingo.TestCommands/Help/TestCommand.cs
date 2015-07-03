using System.Collections;
using System.ComponentModel.Composition;
using Pingo.CommandLine;
using Pingo.CommandLine.Contracts.Command;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Contracts.Help;
using Pingo.CommandLine.Execute;

namespace Pingo.TestCommands.Help
{
    [Export(typeof(ICommandHelp))]
    [ExportMetadata("Command", "Test")]
    public class HelpCommand : ICommandHelp
    {
        private System.Collections.SortedList _sortedOptionHelps;
        public string Name { get { return Resources.Common.Name; } }

        public string Description { get { return Resources.Common.Description; } }
        public string Usage { get { return Resources.Common.UsageFragment; } }
        public string Detailed { get { return Resources.Common.Description; } }
        public SortedList Options
        {
            get
            {
                if (_sortedOptionHelps == null)
                {
                    _sortedOptionHelps = new SortedList();
                    _sortedOptionHelps.Add("-Source", new OptionHelp()
                    {
                        Name = "-Source",
                        Description = "Source Description",
                        Usage = "Source Usage"
                    });

                }
                return _sortedOptionHelps;
            }
        }
    }
}
