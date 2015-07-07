using System.Collections;
using System.ComponentModel.Composition;
using Pingo.CommandLine;

namespace Pingo.JsonConverters.Commands.Help
{
    [Export(typeof(Pingo.CommandLine.Contracts.Help.ICommandHelp))]
    [ExportMetadata("Command", "JsonSchema")]
    public class JsonSchema : Pingo.CommandLine.Contracts.Help.ICommandHelp
    {
        private System.Collections.SortedList _sortedOptionHelps;

        public string Name
        {
            get { return Resources.Common.Name_JsonSchema; }
        }

        public string Description
        {
            get { return Resources.Common.Description_JsonSchema; }
        }

        public string Usage
        {
            get { return Resources.Common.UsageFragment_JsonSchema; }
        }

        public string Detailed
        {
            get { return Resources.Common.Description_JsonSchema; }
        }

        public SortedList Options
        {
            get
            {
                if (_sortedOptionHelps == null)
                {
                    var optionNameSource = "-" + Resources.Common.OptionLongName_Source;
                    var optionNameSchema = "-" + Resources.Common.OptionLongName_Schema;
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
                            optionNameSchema, new OptionHelp()
                            {
                                Name = optionNameSchema,
                                Description = Resources.Common.OptionDescription_Schema_Json,
                                Usage =
                                    string.Format(Resources.Common.Format_OptionUsage,
                                        optionNameSchema, Resources.Common.Argument_PathToJsonSchema)
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
