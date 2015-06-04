using System;
using System.Runtime.CompilerServices;

namespace Json2Xml
{
    class Program
    {
        private static void Main(string[] args)
        {

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Json2Xml.PingoEmbeddedAssemblies.AssemblyResolver.OnResolveAssembly);
            MainCore(args);
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void MainCore(string[] args)
        {
            Json2Xml.Core.Program.Main(args);
        }
    }
}
