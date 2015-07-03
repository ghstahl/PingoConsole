using System.Collections.Generic;
using System.Linq;
using Pingo.CommandLine.Contracts.Execute;

namespace Pingo.CommandLine.Execute
{
    public sealed class ExecuteResult : IExecuteResult
    {

        public static ExecuteResult NewExecuteResult(string errorText)
        {
            var error = new ExecuteError() { ErrorText = errorText };
            var executeResult = new ExecuteResult();
            executeResult.ErrorsStore.Add(error);
            return executeResult;
        } 
        
        private List<IExecuteError> _errors;

        public IEnumerable<IExecuteError> Errors
        {
            get { return ErrorsStore; }
        }

        public string Name { get; set; }

        public List<IExecuteError> ErrorsStore
        {
            get { return _errors ?? (_errors = new List<IExecuteError>()); }
        }

        public string ErrorText { get; set; }

        public bool HasErrors
        {
            get { return Errors.Any(); }
        }
    }
}