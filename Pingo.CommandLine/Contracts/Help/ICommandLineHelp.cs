namespace Pingo.CommandLine.Contracts.Help
{
    public interface ICommandLineHelp
    {
        void Add(IHelpResource helpResource);
        void Add(ICommandHelp commandHelp);
    }
}