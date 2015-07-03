namespace Pingo.CommandLine.Contracts.Help
{
    public interface IOptionHelp
    {
        string Name { get; }
        string Description { get; }
        string Usage { get; }
    }
}