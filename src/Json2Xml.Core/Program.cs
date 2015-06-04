using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fclp;
using Json2Xml.Core.IO;

namespace Json2Xml.Core
{
    public class Wellknown
    {
        public const string Json2Xml = "Json2Xml";
        public const string Xml2Json = "Xml2Json";
    }
    public static class Program
    {
        private const int ERROR_BAD_ARGUMENTS = 0xA0;
        private const int ERROR_ARITHMETIC_OVERFLOW = 0x216;
        private const int ERROR_INVALID_COMMAND_LINE = 0x667;


        public static string CoverageFile;
        public static string Output;
        public static string Command = Wellknown.Json2Xml;
        public static void Main(string[] args)
        {
            DumpWelcomeHeader();
            DumpAssemblyInfo();
            Console.WriteLine();

            var p = new FluentCommandLineParser();
            var pResult = p.ProcessArguments(args);
            if (pResult.HasErrors)
            {
                DoConsoleErrorColor(() => Console.WriteLine(pResult.ErrorText));

                // dump information.
                p.Options.HelpDumpOptions();
                ParserHelp.HelpDumpUsage();
                Environment.ExitCode = ERROR_BAD_ARGUMENTS;
            }
            if (!ValidateArguments())
            {
                p.Options.HelpDumpOptions();
                ParserHelp.HelpDumpUsage();
                Environment.ExitCode = ERROR_BAD_ARGUMENTS;
            }

        }

        static bool ValidateArguments()
        {
            bool valid = FileSystem.CanCreate(Output);
            if (!valid)
            {
                DoConsoleErrorColor(() => Console.WriteLine(Json2Xml.Resources.Common.Error_OutputFileCanNotBeCreated, Output));
            }
            
            return valid;
        }
        static ICommandLineParserResult ProcessArguments(this FluentCommandLineParser p, string[] args)
        {

            // Source Switch
            p.Setup<string>(Json2Xml.Resources.Common.Switch_SourceShort[0], Json2Xml.Resources.Common.Switch_SourceLong)
                .Callback(value => CoverageFile = value)
                .Required()
                .WithDescription(Json2Xml.Resources.Common.Switch_SourceDescription);

            // Output Switch
            p.Setup<string>(Json2Xml.Resources.Common.Switch_OutputShort[0], Json2Xml.Resources.Common.Switch_OutputLong)
               .Callback(value => Output = value)
               .Required()
               .WithDescription(Json2Xml.Resources.Common.Switch_OutputDescription);


            // Command Switch
            var description = string.Format(Json2Xml.Resources.Common.Switch_CommandDescription, Wellknown.Json2Xml, Wellknown.Xml2Json);
            p.Setup<string>(Json2Xml.Resources.Common.Switch_CommandShort[0], Json2Xml.Resources.Common.Switch_CommandLong)
                .Callback(value => Command = value)
                .WithDescription(description);
            
            return  p.Parse(args);
        }

        private static void DumpAssemblyInfo()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            DumpAssemblyInfo(assembly);
            assembly = typeof(Newtonsoft.Json.JsonSerializer).Assembly;
            DumpAssemblyInfo(assembly);
        }
        private static void DumpAssemblyInfo(Assembly assembly)
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            Console.WriteLine("{0} AssemblyVersion:[{1}] FileVersion:[{2}]", assembly.GetName().Name, assembly.GetName().Version, version);
        }
        private static void DumpWelcomeHeader()
        {
            string[] cultureNames = { "en-US", "fr-FR", "ru-RU", "es-ES", "de-DE", "en-US" };
            var assembly = typeof(Json2Xml.Resources.Common).Assembly;

            var rm = new ResourceManager("Json2Xml.Resources.Common", assembly);
            foreach (var cultureName in cultureNames)
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;

                string welcome = rm.GetString("Welcome");
                Console.Write("{0} ", welcome);
            }
            Console.WriteLine("");
        }

        private static void DoConsoleErrorColor(Action action)
        {
            try
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                action();
            }
            finally
            {
                Console.ResetColor();
            }
        }
     
    }
}
