using System.Collections;
using System.ComponentModel.Composition;
using Pingo.CommandLine;

namespace Pingo.JsonConverters.Commands.Help
{
    [Export(typeof(Pingo.CommandLine.Contracts.Help.ICommandHelp))]
    [ExportMetadata("Command", "cshtml2json")]
    public class Cshtml2JsonCommand : Pingo.CommandLine.Contracts.Help.ICommandHelp
    {
        private System.Collections.SortedList _sortedOptionHelps;

        public string Name
        {
            get { return Resources.Common.Name_cshtml2json; }
        }

        public string Description
        {
            get { return Resources.Common.Description_cshtml2json; }
        }

        public string Usage
        {
            get { return Resources.Common.UsageFragment_cshtml2json; }
        }

        public string Detailed
        {
            get { return Resources.Common.Description_cshtml2json; }
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
                                Description = Resources.Common.OptionDescription_Source_cshtml2json,
                                Usage =
                                    string.Format(Resources.Common.Format_OptionUsage,
                                        optionNameSource, Resources.Common.Argument_PathToXml)
                            }
                        },
                        {
                            optionNameOutput, new OptionHelp()
                            {
                                Name = optionNameOutput,
                                Description = Resources.Common.OptionDescription_Output_cshtml2json,
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