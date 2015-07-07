using System.Collections;
using System.ComponentModel.Composition;
using Pingo.CommandLineHelp.Resources;

namespace Pingo.CommandLineHelp.Help
{


    [Export(typeof(Pingo.CommandLine.Contracts.Help.ICommandHelp))]
    [ExportMetadata("Command", "Help")]
    public class HelpCommand : Pingo.CommandLine.Contracts.Help.ICommandHelp
    {
        private System.Collections.SortedList _sortedOptionHelps;
        public string Name { get { return HelpResources.Name_Help; } }
        public string Description { get { return HelpResources.Description_Help; } }
        public string Usage { get { return HelpResources.Usage; } }
        public string Detailed { get { return HelpResources.Description_Detailed; } }

        public SortedList Options
        {
            get
            {
                return _sortedOptionHelps;
            }
        }
    }
}
