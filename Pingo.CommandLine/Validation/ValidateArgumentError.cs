namespace Pingo.CommandLine.Validation
{
    public sealed class ValidateArgumentError : IValidateArgumentError
    {
        public string ErrorText { get; set; }
    }
}