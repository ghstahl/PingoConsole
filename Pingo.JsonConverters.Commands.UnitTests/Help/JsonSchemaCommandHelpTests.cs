using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pingo.JsonConverters.Commands.UnitTests.Help
{
    [TestClass]
    public class JsonSchemaCommandHelpTests : CommandHelpTests
    {
        [ClassInitialize]
        public static void ClassSetup(TestContext a)
        {
            Console.WriteLine("Class Setup");
            CommandHelp = new JsonConverters.Commands.Help.JsonSchema();
        }
    }
}