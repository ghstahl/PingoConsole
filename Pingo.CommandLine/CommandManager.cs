using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Pingo.CommandLine.Composite;
using Pingo.CommandLine.Contracts.Command;
using Pingo.CommandLine.Contracts.Help;

namespace Pingo.CommandLine
{
    public class CommandManager
    {
        private Dictionary<string, Lazy<ICommand, ICommandMetaData>> _commandMap;

        public Dictionary<string, Lazy<ICommand, ICommandMetaData>> CommandMap
        {
            get { return _commandMap ?? (_commandMap = new Dictionary<string, Lazy<ICommand, ICommandMetaData>>()); }
        }

        [Import(typeof(ICommandLineHelp))]
        public ICommandLineHelp CommandLineHelp;

        [ImportMany]
        public IEnumerable<Lazy<ICommand, ICommandMetaData>> Commands;

        [ImportMany]
        public IEnumerable<Lazy<ICommandHelp, ICommandMetaData>> CommandHelps;

        private readonly IAssemblyAccumulator _assemblAccumulator;
        public CommandManager(IAssemblyAccumulator assmblAccumulator)
        {
            _assemblAccumulator = assmblAccumulator;
        }


        public void BuildContainer()
        {
            this.ComposeParts(_assemblAccumulator);

            if (!Commands.Any())
            {
                throw new Exception("No ICommandOptionParser objects found");
            }
            
            // setup the Command Help System
            foreach (var i in CommandHelps)
            {
                CommandLineHelp.Add(i.Value);
            }


            foreach (Lazy<ICommand, ICommandMetaData> i in Commands)
            {
                CommandMap.Add(i.Metadata.Command,i);
            }

        }

    }
}
