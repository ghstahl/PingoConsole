using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Pingo.CommandLine.Composite;

namespace Pingo.CommandLine
{
    public class CommandManager
    {
        private Dictionary<string, Lazy<Pingo.CommandLine.Contracts.Command.ICommand, Pingo.CommandLine.Contracts.Command.ICommandMetaData>> _commandMap;

        public Dictionary<string, Lazy<Pingo.CommandLine.Contracts.Command.ICommand, Pingo.CommandLine.Contracts.Command.ICommandMetaData>> CommandMap
        {
            get { return _commandMap ?? (_commandMap = new Dictionary<string, Lazy<Pingo.CommandLine.Contracts.Command.ICommand, Pingo.CommandLine.Contracts.Command.ICommandMetaData>>()); }
        }

        [Import(typeof(Pingo.CommandLine.Contracts.Help.ICommandLineHelp))]
        public Pingo.CommandLine.Contracts.Help.ICommandLineHelp CommandLineHelp;

        [Import(typeof(Pingo.CommandLine.Contracts.Help.IHelpResource), AllowDefault = true)]
        public Pingo.CommandLine.Contracts.Help.IHelpResource HelpResource;

        [ImportMany]
        public IEnumerable<Lazy<Pingo.CommandLine.Contracts.Command.ICommand, Pingo.CommandLine.Contracts.Command.ICommandMetaData>> Commands;

        [ImportMany]
        public IEnumerable<Lazy<Pingo.CommandLine.Contracts.Help.ICommandHelp, Pingo.CommandLine.Contracts.Command.ICommandMetaData>> CommandHelps;

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


            foreach (Lazy<Pingo.CommandLine.Contracts.Command.ICommand, Pingo.CommandLine.Contracts.Command.ICommandMetaData> i in Commands)
            {
                CommandMap.Add(i.Metadata.Command,i);
            }

        }

    }
}
