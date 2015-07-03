using Pingo.CommandLine.Contracts.Execute;

namespace Pingo.CommandLine.Execute
{
    public sealed class ExecuteError : IExecuteError
    {
        public string ErrorText { get; set; }
    }
}