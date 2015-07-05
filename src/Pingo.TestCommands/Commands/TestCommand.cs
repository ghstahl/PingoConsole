using System;
using System.ComponentModel.Composition;
using Pingo.CommandLine.Contracts.Command;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Execute;
using Pingo.TestCommands.Executables;
using Pingo.TestCommands.Parser;

namespace Pingo.TestCommands.Commands
{
    [Export(typeof (ICommand))]
    [ExportMetadata("Command", "Test")]
    public class TestCommand : ICommand
    {
        public IExecuteResult ExecuteCommand(string[] args)
        {
            var executeResult = new ExecuteResult {Name = Resources.Common.Name_Test};
            IExecuteResult finalResult = executeResult;
            try
            {
                var parser = new TestArgumentParser();
                parser.Parse(args);

                var executable = new TestExecutable {Source = parser.SourcePath, Output = parser.OutputPath};
                finalResult = executable.Execute();
                executeResult.ResultCode = (int)ResultCodes.Success;
            }
            catch (Exception e)
            {
                var executeError = new ExecuteError {ErrorText = e.Message};
                executeResult.ErrorsStore.Add(executeError);
                executeResult.ResultCode = (int)ResultCodes.Fail;
            }
            return finalResult;
        }
    }
}
