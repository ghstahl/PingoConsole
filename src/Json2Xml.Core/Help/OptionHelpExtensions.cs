using System;
using Fclp.Internals;
using Pingo.CommandLine.String;

namespace Json2Xml.Core.Help
{
    public static class OptionHelpExtensions
    {
        public static string SwitchHeader(this ICommandLineOption option)
        {
            string output = "";
            // switches.
            output += Json2Xml.Resources.Common.Title_Switches;
            output += Environment.NewLine;
            if (option.HasShortName)
            {
                output += string.Format("{0}{1}{2}", HelpStringHelpers.GetIndentString(1),
                    "[" + Fclp.Internals.SpecialCharacters.ShortOptionPrefix.ToSeparator('|') + "]",
                    option.ShortName);
                output += Environment.NewLine;
            }
            if (option.HasLongName)
            {
                output += string.Format("{0}{1}{2}", HelpStringHelpers.GetIndentString(1),
                    "[" + Fclp.Internals.SpecialCharacters.OptionPrefix.ToSeparator('|') + "]",
                    option.LongName);

                output += Environment.NewLine;
            }
            return output;
        }
    }
}