using System;
using System.Collections.Generic;
using Fclp.Internals;

namespace Json2Xml.Core.Help
{
    public class EnumArgumentSimpleOptionHelpRecord<T> : OptionHelpRecord
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
                string output = Json2Xml.Resources.Common.Title_Description + Environment.NewLine;
                output += string.Format("{0}{1}", HelpStringHelpers.GetIndentString(1), Option.Description) + Environment.NewLine;

                output += Option.SwitchHeader();
                output += Json2Xml.Resources.Common.Title_Arguments;
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