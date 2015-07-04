using System.Collections;
using System.ComponentModel.Composition;
using Pingo.CommandLine;
using Pingo.CommandLine.Contracts.Help;

namespace Pingo.TestCommands.Help
{
    [Export(typeof (ICommandHelp))]
    [ExportMetadata("Command", "Test")]
    public class TestCommandHelp : ICommandHelp
    {
        private System.Collections.SortedList _sortedOptionHelps;

        public string Name
        {
            get { return Resources.Common.Name_Test; }
        }

        public string Description
        {
            get { return Resources.Common.Description_Test; }
        }

        public string Usage
        {
            get { return Resources.Common.UsageFragment_Test; }
        }

        public string Detailed
        {
            get { return Resources.Common.Description_Test; }
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
                                Description = Resources.Common.OptionDescription_Source_Test,
                                Usage =
                                    string.Format(Resources.Common.Format_OptionUsage,
                                        optionNameSource, Resources.Common.Argument_PathToSource)
                            }
                        },
                        {
                            optionNameOutput, new OptionHelp()
                            {
                                Name = optionNameOutput,
                                Description = Resources.Common.OptionDescription_Output_Test,
                                Usage =
                                    string.Format(Resources.Common.Format_OptionUsage,
                                        optionNameOutput, Resources.Common.Argument_PathToOutput)
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
