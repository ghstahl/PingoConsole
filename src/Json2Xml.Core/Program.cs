using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading;
using Json2Xml.Core.CommandLine;
using Json2Xml.Core.Executables;
using Pingo.CommandLine.Execute;
using Pingo.CommandLine.IO;
using Pingo.CommandLine.Validation;

namespace Json2Xml.Core
{
    public static class Program
    {


       
        public static void Main(string[] args)
        {
            DumpWelcomeHeader();
            DumpAssemblyInfo();
            Console.WriteLine();

            var tupleResult = CommandLine.Parser.ProcessArguments(args);

            if (tupleResult.Item2.HasErrors)
            {
                tupleResult.DumpErrorOutput();
                return;
            }
            var resultValidateArguments = ValidateArguments();
            if (resultValidateArguments.HasErrors)
            {
                ConsoleHelper.DoConsoleErrorColor(() => Console.WriteLine(resultValidateArguments.ErrorText));
                foreach (var errors in resultValidateArguments.Errors)
                {
                    ConsoleHelper.DoConsoleErrorColor(() => Console.WriteLine(errors.ErrorText));
                }
                Console.WriteLine();
                tupleResult.Item1.Options.HelpDumpOptions();
                Parser.HelpDumpUsage();
                Environment.ExitCode = Wellknown.ERROR_BAD_ARGUMENTS;
                
                return;
            }

            var executables = BuildExecutables();
            var executablesResult = executables.Execute();

            foreach (var executableResult in executablesResult)
            {
                if (executableResult.HasErrors)
                {
                    ConsoleHelper.DoConsoleErrorColor(() => Console.WriteLine("Failed : {0} : {1}"
                        , executableResult.Name, executableResult.ErrorText));
                }
                else
                {
                    ConsoleHelper.DoConsoleSuccessColor(() => Console.WriteLine("Succeeded : {0} "
                        , executableResult.Name));
                }
            }

        }


        private static IEnumerable<IExecutable> BuildExecutables()
        {
            var executables = new List<IExecutable>();
            switch (Parser.ConversionType)
            {
                case Wellknown.ConversionType.Json2Xml:
                {
                    var executable = new Json2XmlExecutable {Source = Parser.Source, Output = Parser.Output};
                    executables.Add(executable);
                }
                    break;
                case Wellknown.ConversionType.Xml2Json:
                {
                    var executable = new Xml2JsonExecutable {Source = Parser.Source, Output = Parser.Output};
                    executables.Add(executable);
                }
                    break;
            }
            return executables;
        }

        private static IEnumerable<IExecuteResult> Execute(this IEnumerable<IExecutable> executables)
        {
            var executeResults = new List<IExecuteResult>();
            foreach (var executable in executables)
            {
                executeResults.Add(executable.Execute());
            }
            return executeResults;
        }

        /*
         *
         
        -s "H:\MyNugets\test.json"   -o "H:\MyNugets\test.nuspec" -c Json2Xml
        -s "H:\MyNugets\package.nuspec" -o "H:\MyNugets\test.json"   -c Xml2Json
 
         * 
         */

        static IValidateArgumentsResult ValidateArguments()
        {
            var result = new ValidateArgumentsResult();

            bool valid = FileSystem.CanCreate(Parser.Output);
            if (!valid)
            {
                result.ErrorsStore.Add(new ValidateArgumentError()
                {
                    ErrorText = string.Format(Json2Xml.Resources.Common.Error_OutputFileCanNotBeCreated, Parser.Output)
                });
            
            }

            if (!File.Exists(Parser.Source))
            {
                result.ErrorsStore.Add(new ValidateArgumentError()
                {
                    ErrorText = string.Format(Json2Xml.Resources.Common.Error_SourceFileDoesNotExist, Parser.Source)
                });
            }

            if (result.HasErrors)
            {
                result.ErrorText = Json2Xml.Resources.Common.Error_ValidateArgumentsSummary;
            }
            return result;
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
    }
}
