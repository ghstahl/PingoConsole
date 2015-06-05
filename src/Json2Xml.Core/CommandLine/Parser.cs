using System;
using System.Collections.Generic;
using Fclp;
using Fclp.Internals;
using ParserTupleResult = System.Tuple<Fclp.FluentCommandLineParser, Fclp.ICommandLineParserResult>;

namespace Json2Xml.Core.CommandLine
{

    public static class Parser
    {
        public static string Source;
        public static string Output;
        public static Wellknown.ConversionType ConversionType;

        public static ParserTupleResult ProcessArguments(string[] args)
        {
            var p = new FluentCommandLineParser();

            p.Setup<string>(Json2Xml.Resources.Common.Switch_SourceShort[0], Json2Xml.Resources.Common.Switch_SourceLong)
                .Callback(value => Source = value)
                .Required()
                .WithDescription(Json2Xml.Resources.Common.Switch_SourceDescription);

            // Output Switch
            p.Setup<string>(Json2Xml.Resources.Common.Switch_OutputShort[0], Json2Xml.Resources.Common.Switch_OutputLong)
               .Callback(value => Output = value)
               .Required()
               .WithDescription(Json2Xml.Resources.Common.Switch_OutputDescription);


            // Command Switch
            var description = string.Format(Json2Xml.Resources.Common.Switch_CommandDescription, Wellknown.Json2Xml, Wellknown.Xml2Json);
            p.Setup<Wellknown.ConversionType>(Json2Xml.Resources.Common.Switch_CommandShort[0], Json2Xml.Resources.Common.Switch_CommandLong)
                .Callback(value => ConversionType = value)
                .SetDefault(Wellknown.ConversionType.Json2Xml)
                .WithDescription(description);


            //p.SetupHelp()

            var result = p.Parse(args);

            var tuple = new Tuple<FluentCommandLineParser, ICommandLineParserResult>(p, result);

            return tuple;
        }

        public static void DumpErrorOutput(this ParserTupleResult tupleResult)
        {
            ConsoleHelper.DoConsoleErrorColor(() => Console.WriteLine(tupleResult.Item2.ErrorText));

            // dump information.
            tupleResult.Item1.Options.HelpDumpOptions();
            HelpDumpUsage();
            Environment.ExitCode = Wellknown.ERROR_BAD_ARGUMENTS;
        }

        public static void HelpDumpOptions(this List<ICommandLineOption> options)
        {
            foreach (var option in options)
            {
                option.HelpDumpOption();
                Console.WriteLine();
            }
        }

        public static void HelpDumpOption(this ICommandLineOption commandLineOption)
        {
            Console.WriteLine(string.Format("Description: {0}", commandLineOption.Description));

            var command = "[";
            if (commandLineOption.HasShortName)
            {
                command += "-" + commandLineOption.ShortName;
            }
            if (commandLineOption.HasShortName && commandLineOption.HasLongName)
            {
                command += "|";
            }
            if (commandLineOption.HasLongName)
            {
                command += "--" + commandLineOption.LongName;
            }
            command += "]";

            Console.WriteLine(string.Format("    Command:{0}", command));
        }

        public static void HelpDumpUsage()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Console.WriteLine("");
            Console.WriteLine("Usage:");
            Console.WriteLine("Template: {0}.exe [-c|--CoverageFile] <path to .coverage file> [-o|--Output] <path to xml file> ", assembly.GetName().Name);
            Console.WriteLine("Actual: {0}.exe --CoverageFile \"h:\\Some\\Path\\abc.coverage\" --Output \"h:\\SomePath\\To\\MyOutput.XML\" ", assembly.GetName().Name);
        }
    }
}
