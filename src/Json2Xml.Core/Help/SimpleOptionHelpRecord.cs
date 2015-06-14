using Fclp.Internals;

namespace Json2Xml.Core.Help
{
    public class SimpleOptionHelpRecord : Pingo.FluentCommandLineParser.Contrib.Help.SimpleOptionHelpRecord
    {
        public SimpleOptionHelpRecord(ICommandLineOption option) : base(option)
        {
        }
        public override string AquireString(StringResources id)
        {
            switch (id)
            {
                case StringResources.None:
                    return Json2Xml.Resources.Common.None;
                case StringResources.DescriptionTitle:
                    return Json2Xml.Resources.Common.Title_Description;
                case StringResources.ArgumentsTitle:
                    return Json2Xml.Resources.Common.Title_Arguments;
                case StringResources.SwitchesTitle:
                    return Json2Xml.Resources.Common.Title_Switches;
                default:
                    return null;
            }
        }
    }
}