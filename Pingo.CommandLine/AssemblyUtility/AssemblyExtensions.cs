using System.IO;
using System.Reflection;

namespace Pingo.CommandLine.AssemblyUtility
{
    public static class AssemblyExtensions
    {
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
    }
}