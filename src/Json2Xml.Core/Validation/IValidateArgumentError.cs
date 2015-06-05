namespace Json2Xml.Core.Validation
{
    
    /// <summary>
    /// Represents an error that has occurred whilst validating arguments
    /// </summary>
    public interface IValidateArgumentError
    {
        /// <summary>
        /// Gets any formatted error for this error.
        /// </summary>
        string ErrorText { get; }
    }
}