using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.CommandLine.Contracts.Help
{
    public interface ICommandHelp
    {
        string Name { get; }
        string Description { get; }
        string Usage { get; }
        string Detailed { get; }

        SortedList Options { get; }
    
    }
}
