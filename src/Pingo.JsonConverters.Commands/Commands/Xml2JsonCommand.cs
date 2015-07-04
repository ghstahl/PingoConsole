using System;
using System.ComponentModel.Composition;
using Pingo.CommandLine.Contracts.Command;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Execute;
using Pingo.JsonConverters.Commands.Executables;
using Pingo.JsonConverters.Commands.Parser;

namespace Pingo.JsonConverters.Commands.Commands
{
    [Export(typeof(ICommand))]
    [ExportMetadata("Command", "Xml2Json")]
    public class Xml2JsonCommand : ICommand
    {
        public IExecuteResult ExecuteCommand(string[] args)
        {
            var executeResult = new ExecuteResult { Name = "Xml2Json" };
            IExecuteResult finalResult = executeResult;
            try
            {
                var parser = new Json2XmlArgumentParser();
                parser.Parse(args);

                var executable = new Xml2JsonExecutable() { Source = parser.SourcePath, Output = parser.OutputPath };
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