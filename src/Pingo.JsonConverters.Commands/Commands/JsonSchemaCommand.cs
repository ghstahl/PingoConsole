using System;
using System.ComponentModel.Composition;
using Pingo.CommandLine.Contracts.Command;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Execute;
using Pingo.JsonConverters.Commands.Executables;
using Pingo.JsonConverters.Commands.Parser;

namespace Pingo.JsonConverters.Commands.Commands
{
    [Export(typeof( ICommand))]
    [ExportMetadata("Command", "JsonSchema")]
    public class JsonSchemaCommand : ICommand
    {
        public IExecuteResult ExecuteCommand(string[] args)
        {
            var executeResult = new ExecuteResult { Name = "JsonSchema" };
            IExecuteResult finalResult = executeResult;
            try
            {
                var parser = new JsonSchemaArgumentParser();
                parser.Parse(args);

                var executable = new JsonSchemaExecutable() {Source = parser.SourcePath, SourceSchema = parser.SourceSchema};
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
