using System.Collections.Generic;
using System.Reflection;

namespace Pingo.MEF.Contrib
{
    public interface IAssemblyAccumulator
    {
        /// <summary>
        /// The List of loaded assemblies
        /// </summary>
        /// <returns>A list of Assemblies</returns>
        IList<Assembly> Assemblies();
    }
}
