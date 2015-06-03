using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingoConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            AppDomain.CurrentDomain.AssemblyResolve +=
                new ResolveEventHandler(PingoConsole.PingoEmbeddedAssemblies.AssemblyResolver.OnResolveAssembly);
            MainCore(args);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void MainCore(string[] args)
        {

            {
                string[] cultureNames = {"en-US", "fr-FR", "ru-RU", "sv-SE"};
                var assembly = typeof(PingoConsole.Resources.Common).Assembly;

                var rm = new ResourceManager("PingoConsole.Resources.Common", assembly);
                foreach (var cultureName in cultureNames)
                {
                    CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;

                    string dateString = rm.GetString("Welcome");
                    Console.WriteLine("{0} {1:M}.\n", dateString, DateTime.Now);
                }



              
                   // Console.WriteLine(PingoConsole.Resources.Common.Welcome);
                // your class as shown is Program
                //  i.e.    CodeCoverageLib.CoverageConverter.LibMain(args);
            }
        }
    }
}
