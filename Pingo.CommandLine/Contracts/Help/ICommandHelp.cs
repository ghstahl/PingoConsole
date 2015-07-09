using System.Collections;

namespace Pingo.CommandLine.Contracts.Help
{
    public interface ICommandHelp
    {
        string Name { get; }
        string Description { get; }
        string Usage { get; }
        string Detailed { get; }
        SortedList Options { get; }
    }
}
