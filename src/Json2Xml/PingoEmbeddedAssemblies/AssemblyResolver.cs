using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace Json2Xml.PingoEmbeddedAssemblies
{
    public static class AssemblyResolver
    {

        public static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = new AssemblyName(args.Name);

            string path = assemblyName.Name + ".dll";
            if (assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture) == false)
            {
                path = String.Format(@"{0}\{1}", assemblyName.CultureInfo, path);
            }

            return executingAssembly.AssemblyFromManifestResourceStream(path);

        }

        public static Assembly AssemblyFromManifestResourceStream(this Assembly assembly, string path)
        {
            using (Stream stream = assembly.GetManifestResourceStream(path))
            {
                if (stream == null)
                    return null;

                byte[] assemblyRawBytes = new byte[stream.Length];
                stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
                return Assembly.Load(assemblyRawBytes);
            }
        }

/*
        private static void Main(string[] args)
        {

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Json2Xml.PingoEmbeddedAssemblies.AssemblyResolver.OnResolveAssembly);
            MainCore(args);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void MainCore(string[] args)
        {
            // your class as shown is Program
        //  i.e.    CodeCoverageLib.CoverageConverter.LibMain(args);
        }
*/
    }
}
