using System;
using System.Runtime.CompilerServices;
using Pingo.CommandLine.Composite;


namespace ConsoleHostForMef
{
   
    class Program
    {
        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += ConsoleHostForMef.PingoEmbeddedAssemblies.AssemblyResolver.OnResolveAssembly;
            MainCore(args);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void MainCore(string[] args)
        {
            Pingo.CommandLine.EntryPoint.Program.MefRunnerEntryPoint(new EntryAssemblyEmbeddedMefAssemblies(), args);
        }
    }
}
