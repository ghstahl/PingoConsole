using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.CommandLine.Fluent
{
    public interface ICommandLineOptionHelpContainer
    {
        ICommandLineOptionHelpFluent Setup(string optionName, string shortName, string longName);
    }
}
