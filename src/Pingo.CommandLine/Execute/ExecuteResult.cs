using System.Collections.Generic;
using System.Linq;

namespace Pingo.CommandLine.Execute
{
    public sealed class ExecuteResult : IExecuteResult
    {
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