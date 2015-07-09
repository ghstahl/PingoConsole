using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pingo.CommandLine.Composite;
using Pingo.JsonConverters.Commands.Commands;

namespace Pingo.JsonConverters.Commands.UnitTests.Help
{
    [TestClass]
    public class Json2XmlCommandHelpTests : CommandHelpTests
    {
        [ClassInitialize]
        public static void ClassSetup(TestContext a)
        {
            Console.WriteLine("Class Setup");
            CommandHelp = new JsonConverters.Commands.Help.Json2XmlCommand();
        }
    }
}
