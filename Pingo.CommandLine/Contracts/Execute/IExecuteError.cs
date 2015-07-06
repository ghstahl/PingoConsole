namespace Pingo.CommandLine.Contracts.Execute
{
    
    /// <summary>
    /// Represents an error that has occurred whilst executing a command
    /// </summary>
    public interface IExecuteError
    {
        /// <summary>
        /// Gets any formatted error for this error.
        /// </summary>
        string ErrorText { get; }
    }
}