using System.Collections.Generic;

namespace Pingo.CommandLine.Fluent
{
    public class CommandLineOptionHelpContainer : ICommandLineOptionHelpContainer
    {
        private Dictionary<string, ICommandLineOptionHelpFluent> _collectionCommandLineOptionHelpFluent;

        public Dictionary<string,ICommandLineOptionHelpFluent> CollectionCommandLineOptionHelpFluent
        {
            get {
                return _collectionCommandLineOptionHelpFluent ??
                       (_collectionCommandLineOptionHelpFluent = new Dictionary<string, ICommandLineOptionHelpFluent>());
            }
        }
 
        public ICommandLineOptionHelpFluent Setup(string optionName, string shortName, string longName)
        {
            var clohf = new CommandLineOptionHelpFluent()
                .SetShortName(shortName)
                .SetLongName(longName);
            CollectionCommandLineOptionHelpFluent.Add(optionName,clohf);
            return clohf;
        }
    }
}