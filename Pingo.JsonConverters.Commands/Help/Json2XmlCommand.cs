using System.Collections;
using System.ComponentModel.Composition;
using Pingo.CommandLine;

namespace Pingo.JsonConverters.Commands.Help
{
    [Export(typeof(Pingo.CommandLine.Contracts.Help.ICommandHelp))]
    [ExportMetadata("Command", "Json2Xml")]
    public class Json2XmlCommand : Pingo.CommandLine.Contracts.Help.ICommandHelp
    {
        private System.Collections.SortedList _sortedOptionHelps;

        public string Name
        {
            get { return Resources.Common.Name_Json2Xml; }
        }

        public string Description
        {
            get { return Resources.Common.Description_Json2Xml; }
        }

        public string Usage
        {
            get { return Resources.Common.UsageFragment_Json2Xml; }
        }

        public string Detailed
        {
            get { return Resources.Common.Description_Json2Xml; }
        }

        public SortedList Options
        {
            get
            {
                if (_sortedOptionHelps == null)
                {
                    var optionNameSource = "-" + Resources.Common.OptionLongName_Source;
                    var optionNameOutput = "-" + Resources.Common.OptionLongName_Output;
                    _sortedOptionHelps = new SortedList
                    {
                        {
                            optionNameSource, new OptionHelp()
                            {
                                Name = optionNameSource,
                                Description = Resources.Common.OptionDescription_Source_Json2Xml,
                                Usage =
                                    string.Format(Resources.Common.Format_OptionUsage,
                                        optionNameSource, Resources.Common.Argument_PathToJson)
                            }
                        },
                        {
                            optionNameOutput, new OptionHelp()
                            {
                                Name = optionNameOutput,
                                Description = Resources.Common.OptionDescription_Output_Json2Xml,
                                Usage =
                                    string.Format(Resources.Common.Format_OptionUsage,
                                        optionNameOutput, Resources.Common.Argument_PathToXml)
                            }
                        },
                        {
                            Resources.Common.OptionName_Help, new OptionHelp()
                            {
                                Name = Resources.Common.OptionName_Help,
                                Description = Resources.Common.OptionDescription_Help,
                                Usage = Resources.Common.OptionUsage_Help
                            }
                        }

                    };
                }
                return _sortedOptionHelps;
            }
        }
    }
}
