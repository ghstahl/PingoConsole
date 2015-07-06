using System.Security.Cryptography.X509Certificates;

namespace Pingo.CommandLine.Contracts.Help
{
    public interface ICommandLineHelp
    {
        void Add(ICommandHelp commandHelp);
    }
}