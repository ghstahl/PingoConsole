using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pingo.CommandLine.Fluent
{
    // Summary:
    //     Provides the fluent interface for a Pingo.CommandLine.Fluent.ICommandLineOptionHelpFluent object.
    public interface ICommandLineOptionHelpFluent
    {
         
        //
        // Summary:
        //     Declares that this Pingo.CommandLine.Fluent.ICommandLineOptionHelpFluent is required.
        //
        // Returns:
        //     A Pingo.CommandLine.Fluent.ICommandLineOptionHelpFluent.
        ICommandLineOptionHelpFluent Required();

        bool IsRequired { get; }
        //
        // Summary:
        //     Adds the specified description to the Pingo.CommandLine.Fluent.ICommandLineOptionHelpFluent.
        //
        // Parameters:
        //   description:
        //     The System.String representing the description to use. This should be localised
        //     text.
        //
        // Returns:
        //     A Pingo.CommandLine.Fluent.ICommandLineOptionHelpFluent.
        ICommandLineOptionHelpFluent SetDescription(string description);

        string Description { get; }

        //
        // Summary:
        //     Adds a short name option to the Pingo.CommandLine.Fluent.ICommandLineOptionHelpFluent.
        //
        // Parameters:
        //   description:
        //     The System.String representing the short name to use. This should be localised
        //     text.
        //
        // Returns:
        //     A Pingo.CommandLine.Fluent.ICommandLineOptionHelpFluent.
        ICommandLineOptionHelpFluent SetShortName(string name);
        string ShortName { get; }
        //
        // Summary:
        //     Adds a long name option to the Pingo.CommandLine.Fluent.ICommandLineOptionHelpFluent.
        //
        // Parameters:
        //   description:
        //     The System.String representing the long name to use. This should be localised
        //     text.
        //
        // Returns:
        //     A Pingo.CommandLine.Fluent.ICommandLineOptionHelpFluent.
        ICommandLineOptionHelpFluent SetLongName(string name);
        string LongName { get; }

    }
}
