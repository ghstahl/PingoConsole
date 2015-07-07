using System;
using Fclp;

namespace Pingo.JsonConverters.Commands.Parser
{
    public class Json2XmlArgumentParser
    {
        public string SourcePath { get; private set; }
        public string OutputPath { get; private set; }

        public void Parse(string[] args)
        {
            var parser = new Fclp.FluentCommandLineParser();

            parser.Setup<string>(CaseType.CaseInsensitive, Resources.Common.OptionLongName_Source,
                Resources.Common.OptionShortName_Source)
                .Required()
                .Callback(value => SourcePath = value);

            parser.Setup<string>(CaseType.CaseInsensitive, Resources.Common.OptionLongName_Output,
                Resources.Common.OptionShortName_Output)
                .Required()
                .Callback(value => OutputPath = value);

            var result = parser.Parse(args);
            if (result.HasErrors)
            {
                throw new Exception(result.ErrorText);
            }
        }
    }
}
