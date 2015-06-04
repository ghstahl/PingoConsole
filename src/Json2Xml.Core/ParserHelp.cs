using System;
using System.Collections.Generic;
using Fclp.Internals;

namespace Json2Xml.Core
{
    public static class ParserHelp
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
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Console.WriteLine("");
            Console.WriteLine("Usage:");
            Console.WriteLine("Template: {0}.exe [-c|--CoverageFile] <path to .coverage file> [-o|--Output] <path to xml file> ", assembly.GetName().Name);
            Console.WriteLine("Actual: {0}.exe --CoverageFile \"h:\\Some\\Path\\abc.coverage\" --Output \"h:\\SomePath\\To\\MyOutput.XML\" ", assembly.GetName().Name);
        }
    }
}