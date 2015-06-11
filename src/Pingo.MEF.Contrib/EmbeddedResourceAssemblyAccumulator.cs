using System.Collections.Generic;
using System.Reflection;

namespace Pingo.MEF.Contrib
{
    public abstract class EmbeddedResourceAssemblyAccumulator : IAssemblyAccumulator
    {
        /// <summary>
        /// pop
        /// </summary>
        protected static List<string> ResourceNameOfDll = new List<string>();
        private static List<Assembly> _embeddedAssemblies;
        public IList<Assembly> Assemblies()
        {
            if (_embeddedAssemblies == null)
            {
                _embeddedAssemblies = new List<Assembly>();
                foreach (var name in ResourceNameOfDll)
                {
                    _embeddedAssemblies.Add(AssemblyFromManifestResourceStream(name));
                }
            }
            return _embeddedAssemblies;
        }

        /// <summary>
        ///     i.e.
        ///     Assembly executingAssembly = Assembly.GetExecutingAssembly();
        ///    _embeddedAssemblies.Add(executingAssembly.AssemblyFromManifestResourceStream("ReportGenerator.Reporting.dll"));
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected abstract Assembly AssemblyFromManifestResourceStream(string name);
        
    }
}
