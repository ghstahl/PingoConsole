using System.Collections.Generic;
using System.Linq;

namespace Pingo.CommandLine.Validation
{
    public sealed class ValidateArgumentsResult : IValidateArgumentsResult
    {
        private List<IValidateArgumentError> _errors; 
        public IEnumerable<IValidateArgumentError> Errors
        {
            get { return ErrorsStore; }
        }

        public List<IValidateArgumentError> ErrorsStore
        {
            get { return _errors ?? (_errors = new List<IValidateArgumentError>()); }
        }
            

        public string ErrorText { get; set; }

        public bool HasErrors
        {
            get { 
                return Errors.Any();
            }
        }
    }
}