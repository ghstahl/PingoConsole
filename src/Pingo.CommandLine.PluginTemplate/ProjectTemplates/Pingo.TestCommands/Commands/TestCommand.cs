using System;
using System.ComponentModel.Composition;
using Pingo.CommandLine.Contracts.Command;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Execute;
using $safeprojectname$.Executables;
using $safeprojectname$.Parser;

namespace $safeprojectname$.Commands
{
    [Export(typeof (ICommand))]
    [ExportMetadata("Command", "$commandname$")]
    public class $commandname$Command : ICommand
    {
        public IExecuteResult ExecuteCommand(string[] args)
        {
            var executeResult = new ExecuteResult {Name = Resources.Common.Name_$commandname$};
            IExecuteResult finalResult = executeResult;
            try
            {
                var parser = new $commandname$ArgumentParser();
                parser.Parse(args);

                var executable = new $commandname$Executable {Source = parser.SourcePath, Output = parser.OutputPath};
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
