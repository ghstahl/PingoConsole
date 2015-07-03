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
    [ExportMetadata("Command", "Json2Xml")]
    public class Json2XmlCommand : ICommand
    {
        public IExecuteResult ExecuteCommand(string[] args)
        {
            IExecuteResult finalResult;
            var executeResult = new ExecuteResult { Name = "Json2Xml" };
            try
            {
                var parser = new Json2XmlArgumentParser();
                parser.Parse(args);

                var executable = new Json2XmlExecutable {Source = parser.SourcePath, Output = parser.OutputPath};
                finalResult = executable.Execute();
            }
            catch (Exception e)
            {
                var executeError = new ExecuteError { ErrorText = e.Message };
                executeResult.ErrorsStore.Add(executeError);
            }
            finalResult = executeResult;
            return finalResult;
        }
    }
}
