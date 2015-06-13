using System;
using System.Collections.Generic;
using Fclp.Internals;
using Fclp.Internals.Extensions;

namespace Json2Xml.Core.Help
{
    public class SimpleOptionHelpRecord : OptionHelpRecord
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
                string output = Json2Xml.Resources.Common.Title_Description + Environment.NewLine;
                output += string.Format("{0}{1}", HelpStringHelpers.GetIndentString(1), Option.Description) + Environment.NewLine;

                output += Option.SwitchHeader();

                output += Json2Xml.Resources.Common.Title_Arguments;
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
                    output += string.Format("{0}{1}", HelpStringHelpers.GetIndentString(1), Json2Xml.Resources.Common.None);
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