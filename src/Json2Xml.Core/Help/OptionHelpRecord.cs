using Fclp.Internals;

namespace Json2Xml.Core.Help
{
    public abstract class OptionHelpRecord : IOptionHelp
    {
        protected ICommandLineOption Option { get; set; }

        protected OptionHelpRecord(ICommandLineOption option)
        {
            Option = option;
        }
        public abstract string HelpText { get; }
    }
}