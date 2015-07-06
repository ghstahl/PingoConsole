using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Pingo.CommandLine.IO;

namespace Pingo.CommandLine.Composite
{
    /// <summary>
    /// A simple non-recursive implemenation of IAssemblyAccumulator, where Assemblies are loaded from the FileSystem
    /// </summary>
    class FileSystemLocalAssemblyAccumulator : IAssemblyAccumulator
    {
        /// <summary>
        /// The Logger.
        /// </summary>
//        private static readonly ILog Logger = LogManager.GetLogger(typeof(FileSystemLocalAssemblyAccumulator));

        private string _rootPath;
        /// <summary>
        /// Implementation of IAssemblyAccumulator, where Assembiles are loaded from the FileSystem
        /// </summary>
        /// <param name="rootPath">The root directory where the Assemblies to be loaded are</param>
        public FileSystemLocalAssemblyAccumulator(string rootPath)
        {
            _rootPath = rootPath;
        }

        /// <summary>
        /// Returns a list of Assemblies, in this case ones that were loaded from the FileSystem
        /// </summary>
        /// <returns></returns>
        public IList<Assembly> Assemblies()
        {
            var assemblies = new List<Assembly>();
            var directoryInfo = new DirectoryInfo(_rootPath);
            foreach (var file in directoryInfo.EnumerateFiles("*.dll"))
            {
                try
                {
                    // Unblock files, this prevents FileLoadException (e.g. if file was extracted from a ZIP archive)
                    FileUnblocker.Unblock(file.FullName);

                    assemblies.Add(Assembly.LoadFrom(file.FullName));
                }
                catch (FileLoadException)
                {
  //                  Logger.ErrorFormat(Resources.Common.FileLoadError, file.FullName);
                    throw;
                }
                catch (ReflectionTypeLoadException ex)
                {
                    if (!file.Name.Equals("ICSharpCode.NRefactory.Cecil.dll", StringComparison.OrdinalIgnoreCase))
                    {
                        string errors = string.Join(Environment.NewLine, ex.LoaderExceptions.Select(e => "-" + e.Message));
 //                       Logger.ErrorFormat(Resources.Common.FileReflectionLoadError, file.FullName, errors);
                    }

                    // Ignore assemblies that throw this exception
                }
            }
            return assemblies;
        }
    }
}
