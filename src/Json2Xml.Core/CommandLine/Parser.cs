using System;
using System.Collections.Generic;
using Fclp;
using Fclp.Internals;
using Pingo.CommandLine.ConsoleUtility;
using Pingo.CommandLine.EnumUtility;
using Pingo.FluentCommandLineParser.Contrib.Help;
using ParserTupleResult = System.Tuple<Fclp.FluentCommandLineParser, Fclp.ICommandLineParserResult>;
using SimpleOptionHelpRecord = Json2Xml.Core.Help.SimpleOptionHelpRecord;

namespace Json2Xml.Core.CommandLine
{
    public class MyConsoleWriter : Pingo.CommandLine.ConsoleUtility.Writer
    {
        public override string AcquireString(StringResources id)
        {
            switch (id)
            {
                case StringResources.FormatTitleLine:
                    return Json2Xml.Resources.Common.Format_TitleLine;
            }
            return null;

        }
    }

    public static class Parser
    {
        public static bool Help;
        public static string Source;
        public static string Output;
        public static Wellknown.ConversionType ConversionType;

        public static MyConsoleWriter ConsoleWriter = new MyConsoleWriter();
        public static Fclp.ICommandLineParserResult LastResult { get; private set; }
        public static bool ShouldShowHelp()
        {
            if (LastResult == null)
                return false;
            if (LastResult.EmptyArgs)
                return true;
            return Help;
        }

        private static List<IOptionHelp> _listOptionRecords;

        public static List<IOptionHelp> ListOptionRecords
        {
            get { return _listOptionRecords ?? (_listOptionRecords = new List<IOptionHelp>()); }
        }
 
        private static FluentCommandLineParser _fluentCommandLineParser;
        public static FluentCommandLineParser FluentCommandLineParser
        {
            get { return _fluentCommandLineParser ?? (_fluentCommandLineParser = new FluentCommandLineParser()); }
        }

        public static ParserTupleResult ProcessArguments(string[] args)
        {
            var p = FluentCommandLineParser;

            ///////////////////////////////////////////////////////////////////////////////////////////
            // Source Switch
            ///////////////////////////////////////////////////////////////////////////////////////////
            var description = string.Format(Json2Xml.Resources.Common.Switch_SourceDescription,
                Json2Xml.Resources.Common.Switch_SourceShort);
            var sourceOption = FluentCommandLineParser.Setup<string>(Json2Xml.Resources.Common.Switch_SourceShort[0], Json2Xml.Resources.Common.Switch_SourceLong)
                .Callback(value => Source = value)
                .Required()
                .WithDescription(description);
            var sohr = new SimpleOptionHelpRecord((ICommandLineOption) sourceOption);
            sohr.Add(Json2Xml.Resources.Common.ArgumentName_PathToFile,Json2Xml.Resources.Common.ArgumentDescription_PathToFile);
            ListOptionRecords.Add(sohr);

            ///////////////////////////////////////////////////////////////////////////////////////////
            // Output Switch
            ///////////////////////////////////////////////////////////////////////////////////////////
            description = string.Format(Json2Xml.Resources.Common.Switch_OutputDescription,
              Json2Xml.Resources.Common.Switch_OutputShort);
            var outputOption = p.Setup<string>(Json2Xml.Resources.Common.Switch_OutputShort[0], Json2Xml.Resources.Common.Switch_OutputLong)
                .Callback(value => Output = value)
                .Required()
                .WithDescription(description);
            sohr = new SimpleOptionHelpRecord((ICommandLineOption)outputOption);
            sohr.Add(Json2Xml.Resources.Common.ArgumentName_PathToFile, Json2Xml.Resources.Common.ArgumentDescription_PathToFile);
            ListOptionRecords.Add(sohr);


            ///////////////////////////////////////////////////////////////////////////////////////////
            // ConversionType Switch
            ///////////////////////////////////////////////////////////////////////////////////////////
            description = string.Format(Json2Xml.Resources.Common.Switch_ConversionTypeDescription,
                typeof (Wellknown.ConversionType).ToSeparatorEnum('|'),
                Json2Xml.Resources.Common.Switch_ConversionTypeShort,
                typeof(Wellknown.ConversionType).FirstEnum());

            var conversionOption = p.Setup<Wellknown.ConversionType>(Json2Xml.Resources.Common.Switch_ConversionTypeShort[0],
                Json2Xml.Resources.Common.Switch_ConversionTypeLong)
                .Callback(value => ConversionType = value)
                .Required()
                .WithDescription(Json2Xml.Resources.Common.OptionDescription_ConverstionType);

            var enumArgumentSimpleOptionHelpRecord = new Help.EnumArgumentSimpleOptionHelpRecord<Wellknown.ConversionType>((ICommandLineOption)conversionOption);
            enumArgumentSimpleOptionHelpRecord.Add(Wellknown.ConversionType.Json2Xml, Json2Xml.Resources.Common.Description_Json2Xml);
            enumArgumentSimpleOptionHelpRecord.Add(Wellknown.ConversionType.Xml2Json, Json2Xml.Resources.Common.Description_Xml2Json);

            ListOptionRecords.Add(enumArgumentSimpleOptionHelpRecord);


            ///////////////////////////////////////////////////////////////////////////////////////////
            // Help Switch
            ///////////////////////////////////////////////////////////////////////////////////////////
            var helpOption = p.Setup<bool>(Json2Xml.Resources.Common.Switch_HelpShort[0], 
                Json2Xml.Resources.Common.Switch_HelpLong)
               .Callback(help => Help = help)
               .WithDescription(Json2Xml.Resources.Common.OptionDescription_Help)
               .SetDefault(false);
            ListOptionRecords.Add(new SimpleOptionHelpRecord((ICommandLineOption)helpOption));

            LastResult = p.Parse(args);
           
            // force a help if no arguments
            if (LastResult.EmptyArgs)
                Help = true;

            var tuple = new Tuple<FluentCommandLineParser, ICommandLineParserResult>(p, LastResult);

            return tuple;
        }

        public static void DumpErrorOutput(this ParserTupleResult tupleResult)
        {
            ConsoleHelper.DoConsoleErrorColor(() => Console.WriteLine(tupleResult.Item2.ErrorText));

            // dump information.
            WriteHelp();
            WriteHelpUsage();
            Environment.ExitCode = (int)Wellknown.ReturnCodes.BadArguments;
        }



     
        public static void WriteHelp()
        {
            ConsoleWriter.WriteTitleBlock(Json2Xml.Resources.Common.Title_Help);

            Console.WriteLine();

            foreach (var or in ListOptionRecords)
            {
                Pingo.CommandLine.ConsoleUtility.Writer.WriteIndent(Json2Xml.Resources.Common.Breaker_Small, 1);
                Pingo.CommandLine.ConsoleUtility.Writer.WriteIndent(or.HelpText, 1);
            }
        }
        public static void WriteHelpUsage()
        {
            Console.WriteLine(Json2Xml.Resources.Common.Title_Usage);
            Pingo.CommandLine.ConsoleUtility.Writer.WriteIndent(Json2Xml.Resources.Common.Usage, 1);
        }
    }
}
