using System;
using System.Collections.Generic;
using Fclp.Internals;
using Fclp.Internals.Extensions;
using Pingo.CommandLine.String;

namespace Pingo.FluentCommandLineParser.Contrib.Help
{
    public abstract class SimpleOptionHelpRecord : OptionHelpRecord
    {
        private class ArgumentRecord
        {
            public string Item { get; set; }
            public string Description { get; set; }
        }
        private List<ArgumentRecord> _descriptionRecords;
        private List<ArgumentRecord> DescriptionRecords
        {
            get { return _descriptionRecords ?? (_descriptionRecords = new List<ArgumentRecord>()); }
        }

        public SimpleOptionHelpRecord(ICommandLineOption option)
            : base(option)
        {
        }
        public override string HelpText
        {
            get
            {
                string output = AquireString(StringResources.DescriptionTitle) + Environment.NewLine;
                output += string.Format("{0}{1}", HelpStringHelpers.GetIndentString(1), Option.Description) + Environment.NewLine;

                output += Option.SwitchHeader(AquireString(StringResources.SwitchesTitle));

                output += AquireString(StringResources.ArgumentsTitle);
                output += Environment.NewLine;

                foreach (var descriptionRecord in DescriptionRecords)
                {
                    output += string.Format("{0}{1}:", HelpStringHelpers.GetIndentString(1),descriptionRecord.Item);
                    output += Environment.NewLine;
                    output += string.Format("{0}{1}", HelpStringHelpers.GetIndentString(2),
                        descriptionRecord.Description.Replace(Environment.NewLine, Environment.NewLine + HelpStringHelpers.GetIndentString(2)));
                    output += Environment.NewLine;
                }
                if (DescriptionRecords.IsNullOrEmpty())
                {
                    output += string.Format("{0}{1}", HelpStringHelpers.GetIndentString(1), AquireString(StringResources.None));
                    output += Environment.NewLine;
                }
                return output;
            }
        }

        public void Add(string argumentName, string description)
        {
            DescriptionRecords.Add(new ArgumentRecord(){Description = description,Item = argumentName});
        }
    }
}