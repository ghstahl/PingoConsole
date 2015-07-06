using System;
using System.Runtime.CompilerServices;
using Pingo.CommandLine.Composite;

namespace JsonConvert
{
    class Program
    {
        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(JsonConvert.PingoEmbeddedAssemblies.AssemblyResolver.OnResolveAssembly);
            MainCore(args);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void MainCore(string[] args)
        {
            Pingo.CommandLine.EntryPoint.Program.MefRunnerEntryPoint(new EntryAssemblyEmbeddedMefAssemblies(), args);
        }
    }
}
