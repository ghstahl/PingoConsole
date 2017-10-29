using System;
using System.ComponentModel.Composition;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Execute;
using Pingo.JsonConverters.Commands.Executables;
using Pingo.JsonConverters.Commands.Parser;

namespace Pingo.JsonConverters.Commands.Commands
{
    [Export(typeof(Pingo.CommandLine.Contracts.Command.ICommand))]
    [ExportMetadata("Command", "cshtml2json")]
    public class Cshtml2JsonCommand : Pingo.CommandLine.Contracts.Command.ICommand
    {
        public IExecuteResult ExecuteCommand(string[] args)
        {
            var executeResult = new ExecuteResult { Name = "cshtml2json" };
            IExecuteResult finalResult = executeResult;
            try
            {
                var parser = new Cshtml2JsonArgumentParser();
                parser.Parse(args);

                var executable = new Cshtml2JsonExecutable { Source = parser.SourcePath, Output = parser.OutputPath};
                finalResult = executable.Execute();
            }
            catch (Exception e)
            {
                var executeError = new ExecuteError { ErrorText = e.Message };
                executeResult.ErrorsStore.Add(executeError);
            }
            return finalResult;
        }
    }
}
