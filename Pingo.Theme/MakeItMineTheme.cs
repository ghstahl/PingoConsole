using System.ComponentModel.Composition;

namespace Pingo.Theme
{
    [Export(typeof(Pingo.CommandLine.Contracts.Help.IHelpResource))]
    public class MakeItMineTheme : Pingo.CommandLine.Contracts.Help.IHelpResource
    {
        public string Header { get { return Resources.Common.Header; } }
        public string Footer { get { return Resources.Common.Footer; } }
    }
}
