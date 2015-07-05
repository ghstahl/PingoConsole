using System;
using System.IO;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Execute;

namespace $safeprojectname$.Executables
{
    class $commandname$Executable : IExecutable
    {
        public string Source { get; set; }
        public string Output { get; set; }

        public IExecuteResult Execute()
        {
            var executeResult = new ExecuteResult {Name = Resources.Common.Name_$commandname$};
            try
            {
                var fi = new FileInfo(Source);
                if (!fi.Exists)
                {
                    throw new Exception(string.Format(Resources.Common.Format_FileNotFound, fi.FullName));
                }
                fi = new FileInfo(Output);
                if (fi.Exists)
                {
                    throw new Exception(string.Format(Resources.Common.Format_FileAlreadExists,fi.FullName));
                }
            }
            catch (Exception e)
            {
                var executeError = new ExecuteError {ErrorText = e.Message};
                executeResult.ErrorsStore.Add(executeError);
            }
            LastResult = executeResult;
            return LastResult;
        }

        public IExecuteResult LastResult { get; private set; }
    }
}
