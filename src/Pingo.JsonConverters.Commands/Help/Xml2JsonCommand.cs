using System.Collections;
using System.ComponentModel.Composition;
using Pingo.CommandLine;
using Pingo.CommandLine.Contracts.Help;

namespace Pingo.JsonConverters.Commands.Help
{
    [Export(typeof(ICommandHelp))]
    [ExportMetadata("Command", "Xml2Json")]
    public class Xml2JsonCommand : ICommandHelp
    {
        private System.Collections.SortedList _sortedOptionHelps;
        public string Name { get { return Resources.Common.Name_Xml2Json; } }
        public string Description { get { return Resources.Common.Description_Xml2Json; } }
        public string Usage { get { return Resources.Common.UsageFragment_Xml2Json; } }
        public string Detailed { get { return Resources.Common.Description_Xml2Json; } }

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
                                Description = Resources.Common.OptionDescription_Source_Xml2Json,
                                Usage =
                                    string.Format(Resources.Common.Format_OptionUsage,
                                        optionNameSource, Resources.Common.Argument_PathToXml)
                            }
                        },
                        {
                            optionNameOutput, new OptionHelp()
                            {
                                Name = optionNameOutput,
                                Description = Resources.Common.OptionDescription_Output_Xml2Json,
                                Usage =
                                    string.Format(Resources.Common.Format_OptionUsage,
                                        optionNameOutput, Resources.Common.Argument_PathToJson)
                            }
                        },
                        {
                            Resources.Common.OptionName_Help, new OptionHelp()
                            {
                                Name = Resources.Common.OptionName_Help,
                                Description = Resources.Common.OptionDescription_Help,
                                Usage =Resources.Common.OptionUsage_Help
                            }
                        }

                    };
                }
                return _sortedOptionHelps;
            }
        }
    }
}