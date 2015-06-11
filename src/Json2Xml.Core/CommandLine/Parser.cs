using System;
using System.Collections.Generic;
using Fclp;
using Fclp.Internals;
using Pingo.CommandLine.Enum;
using ParserTupleResult = System.Tuple<Fclp.FluentCommandLineParser, Fclp.ICommandLineParserResult>;

namespace Json2Xml.Core.CommandLine
{

    public static class Parser
    {
        private static FluentCommandLineParser _fluentCommandLineParser;
        public static FluentCommandLineParser FluentCommandLineParser
        {
            get { return _fluentCommandLineParser ?? (_fluentCommandLineParser = new FluentCommandLineParser()); }
        }

        public static string Source;
        public static string Output;
        public static Wellknown.ConversionType ConversionType;

        public static ParserTupleResult ProcessArguments(string[] args)
        {
            var p = FluentCommandLineParser;

            // Source Switch
            var description = string.Format(Json2Xml.Resources.Common.Switch_SourceDescription,
                Json2Xml.Resources.Common.Switch_SourceShort);
            FluentCommandLineParser.Setup<string>(Json2Xml.Resources.Common.Switch_SourceShort[0], Json2Xml.Resources.Common.Switch_SourceLong)
                .Callback(value => Source = value)
                .Required()
                .WithDescription(description);

            // Output Switch
            description = string.Format(Json2Xml.Resources.Common.Switch_OutputDescription,
              Json2Xml.Resources.Common.Switch_OutputShort);
            p.Setup<string>(Json2Xml.Resources.Common.Switch_OutputShort[0], Json2Xml.Resources.Common.Switch_OutputLong)
                .Callback(value => Output = value)
                .Required()
                .WithDescription(description);


            // ConversionType Switch
            description = string.Format(Json2Xml.Resources.Common.Switch_ConversionTypeDescription,
                typeof (Wellknown.ConversionType).ToBangEnum(),
                Json2Xml.Resources.Common.Switch_ConversionTypeShort,
                typeof(Wellknown.ConversionType).ToFirstEnum());

            p.Setup<Wellknown.ConversionType>(Json2Xml.Resources.Common.Switch_ConversionTypeShort[0],
                Json2Xml.Resources.Common.Switch_ConversionTypeLong)
                .Callback(value => ConversionType = value)
                .Required()
                .WithDescription(description);


            // sets up the parser to execute the callback when -? or --help is detected
            p.SetupHelp("?", "help")
                .Callback(text =>
                {
                    Console.WriteLine(text);
                });

            var result = p.Parse(args);

            var tuple = new Tuple<FluentCommandLineParser, ICommandLineParserResult>(p, result);

            return tuple;
        }

        public static void DumpErrorOutput(this ParserTupleResult tupleResult)
        {
            ConsoleHelper.DoConsoleErrorColor(() => Console.WriteLine(tupleResult.Item2.ErrorText));

            // dump information.
            HelpDumpOptions();
            HelpDumpUsage();
            Environment.ExitCode = Wellknown.ERROR_BAD_ARGUMENTS;
        }

        public static void HelpDumpOptions( )
        {
            // triggers the SetupHelp Callback which writes the text to the console
       //     FluentCommandLineParser.HelpOption.ShowHelp(FluentCommandLineParser.Options);
        }


        public static void HelpDumpUsage()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
            Console.WriteLine("");
            Console.WriteLine("Usage:");
            Console.WriteLine("Template: {0}.exe [-c|--CoverageFile] <path to .coverage file> [-o|--Output] <path to xml file> ", assembly.GetName().Name);
            Console.WriteLine("Actual: {0}.exe --CoverageFile \"h:\\Some\\Path\\abc.coverage\" --Output \"h:\\SomePath\\To\\MyOutput.XML\" ", assembly.GetName().Name);
        }
    }
}
