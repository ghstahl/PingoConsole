using System.Collections.Generic;
using System.Linq;

namespace Json2Xml.Core.Validation
{
    class ValidateArgumentsResult : IValidateArgumentsResult
    {
        public IEnumerable<IValidateArgumentError> Errors { get; set; }
        public string ErrorText { get; set; }

        public bool HasErrors
        {
            get { 
                return Errors.Any();
            }
        }
    }
}