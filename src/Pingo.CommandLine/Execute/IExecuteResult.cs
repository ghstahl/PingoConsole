using System.Collections.Generic;

namespace Pingo.CommandLine.Execute
{
    /// <summary>
    ///  Represents all the information gained from the result of a execute operation.
    /// </summary>
    public interface IExecuteResult
    {
        /// <summary>
        /// Gets the errors which occurred during the parse operation.
        /// </summary>
        IEnumerable<IExecuteError> Errors { get; }

        /// <summary>
        /// Gets the Name of the result.
        /// </summary>
        string Name { get; }

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