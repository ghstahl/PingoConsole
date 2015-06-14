using Fclp.Internals;

namespace Pingo.FluentCommandLineParser.Contrib.Help
{
    public abstract class OptionHelpRecord : IOptionHelp
    {
        public enum StringResources
        {
            DescriptionTitle,
            SwitchesTitle,
            ArgumentsTitle,
            None
        }
        protected ICommandLineOption Option { get; set; }

        protected OptionHelpRecord(ICommandLineOption option)
        {
            Option = option;
        }
        public abstract string HelpText { get; }
        public abstract string AquireString(StringResources id);
    }
}