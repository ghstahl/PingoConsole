using System;
using System.Collections.Generic;
using Fclp.Internals;
using Pingo.CommandLine.String;

namespace Pingo.FluentCommandLineParser.Contrib.Help
{
    public abstract class EnumArgumentSimpleOptionHelpRecord<T> : OptionHelpRecord
    {
        private class ArgumentRecord
        {
            public T Item { get; set; }
            public string Description { get; set; }
        }
 
        public void Add(T enumItem, string description)
        {
            DescriptionRecords.Add(new ArgumentRecord() { Item = enumItem, Description = description });
        }

        private List<ArgumentRecord> _descriptionRecords;
        private List<ArgumentRecord> DescriptionRecords
        {
            get { return _descriptionRecords ?? (_descriptionRecords = new List<ArgumentRecord>()); }
        }
        public EnumArgumentSimpleOptionHelpRecord(ICommandLineOption option) : base(option)
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

                foreach (var enumItem in DescriptionRecords)
                {
                    output += string.Format("{0}{1}:", HelpStringHelpers.GetIndentString(1),
                        enumItem.Item.ToString());
                    output += Environment.NewLine;
                    output += string.Format("{0}{1}", HelpStringHelpers.GetIndentString(2),
                        enumItem.Description.Replace(Environment.NewLine, Environment.NewLine + HelpStringHelpers.GetIndentString(2)));
                    output += Environment.NewLine;
                }
                return output;
            }
        }
    }
}