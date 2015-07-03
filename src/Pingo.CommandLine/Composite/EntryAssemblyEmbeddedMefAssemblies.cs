using System.Reflection;
using Pingo.CommandLine.AssemblyUtility;

namespace Pingo.CommandLine.Composite
{
    public class EntryAssemblyEmbeddedMefAssemblies : EmbeddedResourceAssemblyAccumulator
    {
        public EntryAssemblyEmbeddedMefAssemblies()
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly(); // is assembly
            foreach (var resourceName in entryAssembly.GetManifestResourceNames())
            {
                if (resourceName.EndsWith(".dll"))
                {
                    ResourceNameOfDll.Add(resourceName);
                }
            }
        }

        protected override Assembly AssemblyFromManifestResourceStream(string name)
        {
            Assembly executingAssembly = Assembly.GetEntryAssembly(); // is assembly
            return executingAssembly.AssemblyFromManifestResourceStream(name);
        }
    }
}