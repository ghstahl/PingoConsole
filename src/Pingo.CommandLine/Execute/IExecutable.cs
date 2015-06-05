namespace Pingo.CommandLine.Execute
{
    /// <summary>
    /// Represents an executable command
    /// </summary>
    public interface IExecutable
    {
        /// <summary>
        /// Executes the command, this is expected to be self contained
        /// </summary>
        /// <returns></returns>
        IExecuteResult Execute();
        /// <summary>
        /// The stored last result, null if never set 
        /// </summary>
        IExecuteResult LastResult { get; }
    }
}