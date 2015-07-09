using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pingo.JsonConverters.Commands.UnitTests.Help
{
    [TestClass]
    public class Xml2JsonCommandHelpTests : CommandHelpTests
    {
        [ClassInitialize]
        public static void ClassSetup(TestContext a)
        {
            Console.WriteLine("Class Setup");
            CommandHelp = new JsonConverters.Commands.Help.Xml2JsonCommand();
        }
    }
}