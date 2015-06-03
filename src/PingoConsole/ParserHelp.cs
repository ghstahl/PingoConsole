using System;
using System.Collections.Generic;
using Fclp.Internals;

namespace PingoConsole
{
    static class ParserHelp
    {
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
            Console.WriteLine("Usage:");
            Console.WriteLine("Template: CodeCoverageConverter.exe [-c|--CoverageFile] <path to .coverage file> [-o|--Output] <path to xml file> ");
            Console.WriteLine("Actual: CodeCoverageConverter.exe --CoverageFile \"h:\\Some\\Path\\abc.coverage\" --Output \"h:\\SomePath\\To\\MyOutput.XML\" ");
        }
    }
}