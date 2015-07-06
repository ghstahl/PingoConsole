using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace Pingo.CommandLine.Composite
{
    public static class AssemblyAccumulatorExtensions
    {
        public static AggregateCatalog ToAggregateCatalog(this IAssemblyAccumulator assemblyAccumulator)
        {
            var aggregateCatalog = new AggregateCatalog();

            foreach (var assembly in assemblyAccumulator.Assemblies())
            {
                var assemblyCatalog = new AssemblyCatalog(assembly);
                assemblyCatalog.Parts.ToArray(); // This may throw ReflectionTypeLoadException 
                aggregateCatalog.Catalogs.Add(assemblyCatalog);
            }
            return aggregateCatalog;
        }
    }
}