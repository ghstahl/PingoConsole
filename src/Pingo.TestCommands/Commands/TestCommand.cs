using System.ComponentModel.Composition;
using Pingo.CommandLine.Contracts.Command;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Execute;

namespace Pingo.TestCommands.Commands
{
    [Export(typeof( ICommand))]
    [ExportMetadata("Command", "Test")]
    public class HelpCommand : ICommand
    {

        public IExecuteResult ExecuteCommand(string[] args)
        {
            return ExecuteResult.NewExecuteResult("Not Implemented");
        }
    }
}
