using System;
using Fclp.Internals;
using Pingo.CommandLine.String;

namespace Pingo.FluentCommandLineParser.Contrib.Help
{
    public static class OptionHelpExtensions
    {
        public static string SwitchHeader(this ICommandLineOption option, string title)
        {
            string output = "";
            // switches.
            output += title;
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