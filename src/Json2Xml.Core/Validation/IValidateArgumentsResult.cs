using System.Collections.Generic;

namespace Json2Xml.Core.Validation
{
    /// <summary>
    ///  Represents all the information gained from the result of a validation operation.
    /// </summary>
    public interface IValidateArgumentsResult
    {
        /// <summary>
        /// Gets the errors which occurred during the parse operation.
        /// </summary>
        IEnumerable<IValidateArgumentError> Errors { get;  }

        /// <summary>
        /// Gets any formatted error for this result.
        /// </summary>
        string ErrorText { get; }

        /// <summary>
        /// Gets whether the validation operation encountered any errors.
        /// </summary>
        bool HasErrors { get; }
       
    }
}