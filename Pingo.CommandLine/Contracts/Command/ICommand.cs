using Pingo.CommandLine.Contracts.Execute;

namespace Pingo.CommandLine.Contracts.Command
{
    public interface ICommand
    {
        IExecuteResult ExecuteCommand(string[] args);
    }
}
