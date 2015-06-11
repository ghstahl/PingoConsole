using System;

namespace Pingo.CommandLine.Fluent
{
    public class CommandLineOptionHelpFluent : ICommandLineOptionHelpFluent
    {
        public ICommandLineOptionHelpFluent Required()
        {
            IsRequired = true;
            return this;
        }

        public bool IsRequired { get; private set; }

        public ICommandLineOptionHelpFluent SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public string Description { get; private set; }

        public ICommandLineOptionHelpFluent SetShortName(string name)
        {
            ShortName = name;
            return this;
        }

        public string ShortName { get; private set; }

        public ICommandLineOptionHelpFluent SetLongName(string name)
        {
            LongName = name;
            return this;
        }

        public string LongName { get; private set; }
    }
}
