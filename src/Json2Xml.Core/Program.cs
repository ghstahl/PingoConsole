using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Fclp;
using Json2Xml.Core.CommandLine;
using Json2Xml.Core.IO;
using Json2Xml.Core.Validation;
using Newtonsoft.Json;

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

            try
            {
                ProcessCommand();
            }
            catch (Exception e)
            {
                
            }

            ConsoleHelper.DoConsoleSuccessColor(() => Console.WriteLine(Json2Xml.Resources.Common.Success));
        }

        /*
         *
         
        -s "H:\MyNugets\test.json"   -o "H:\MyNugets\test.nuspec" -c Json2Xml
        -s "H:\MyNugets\package.nuspec" -o "H:\MyNugets\test.json"   -c Xml2Json
 
         * 
         */
        private static void ProcessCommand()
        {
            if (System.String.Compare(Parser.Command, Wellknown.Json2Xml, System.StringComparison.OrdinalIgnoreCase) == 0)
            {
                var json = File.ReadAllText(Parser.Source);
                var doc = JsonConvert.DeserializeXmlNode(json);
                doc.Save(Parser.Output);
            }
            if (System.String.Compare(Parser.Command, Wellknown.Xml2Json, System.StringComparison.OrdinalIgnoreCase) == 0)
            {
                var doc = new XmlDocument();
                doc.Load(Parser.Source);
                string jsonText = JsonConvert.SerializeXmlNode(doc);
                File.WriteAllText(Parser.Output, jsonText);
            }
        }

        static IValidateArgumentsResult ValidateArguments()
        {
            var result = new ValidateArgumentsResult();
            var errorList = new List<IValidateArgumentError>();
            result.Errors = errorList;
            bool valid = FileSystem.CanCreate(Parser.Output);
            if (!valid)
            {
                errorList.Add(new ValidateArgumentError()
                {
                    ErrorText = string.Format(Json2Xml.Resources.Common.Error_OutputFileCanNotBeCreated, Parser.Output)
                });
            
            }

            if (!File.Exists(Parser.Source))
            {
                errorList.Add(new ValidateArgumentError()
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
