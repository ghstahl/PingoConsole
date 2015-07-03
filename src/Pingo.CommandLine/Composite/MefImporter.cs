using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Pingo.CommandLine.Composite
{
    public static class MefImporter
    {
        public static void ComposeParts<T>(this T targetOjbect,IAssemblyAccumulator AssemblyAccumulator)
        {
            var catalog = AssemblyAccumulator.ToAggregateCatalog();
            var container = new CompositionContainer(catalog);
            container.ComposeParts(targetOjbect);
        }
    }
}
