using Pingo.CommandLine.Contracts.Help;

namespace Pingo.CommandLine
{
    public class OptionHelp : IOptionHelp
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Usage { get; set; }
    }
}
