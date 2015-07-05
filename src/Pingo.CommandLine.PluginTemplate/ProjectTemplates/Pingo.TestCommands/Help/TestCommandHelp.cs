using System.Collections;
using System.ComponentModel.Composition;
using Pingo.CommandLine;
using Pingo.CommandLine.Contracts.Help;

namespace $safeprojectname$.Help
{
    [Export(typeof (ICommandHelp))]
    [ExportMetadata("Command", "$commandname$")]
    public class $commandname$CommandHelp : ICommandHelp
    {
        private System.Collections.SortedList _sortedOptionHelps;

        public string Name
        {
            get { return Resources.Common.Name_$commandname$; }
        }

        public string Description
        {
            get { return Resources.Common.Description_$commandname$; }
        }

        public string Usage
        {
            get { return Resources.Common.UsageFragment_$commandname$; }
        }

        public string Detailed
        {
            get { return Resources.Common.Description_$commandname$; }
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
                                Description = Resources.Common.OptionDescription_Source_$commandname$,
                                Usage =
                                    string.Format(Resources.Common.Format_OptionUsage,
                                        optionNameSource, Resources.Common.Argument_PathToSource)
                            }
                        },
                        {
                            optionNameOutput, new OptionHelp()
                            {
                                Name = optionNameOutput,
                                Description = Resources.Common.OptionDescription_Output_$commandname$,
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
