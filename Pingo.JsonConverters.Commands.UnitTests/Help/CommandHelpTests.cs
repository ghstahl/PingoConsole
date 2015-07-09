using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pingo.JsonConverters.Commands.UnitTests.Help
{

    public class CommandHelpTests
    {
        protected static Pingo.CommandLine.Contracts.Help.ICommandHelp CommandHelp { get; set; }
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Valid_Interface_Descriptions()
        {
            if (CommandHelp == null)
                return;

            Assert.IsFalse(string.IsNullOrWhiteSpace(CommandHelp.Description),
                "CommandHelp.Description IsNullOrWhiteSpace");
        }

        [TestMethod]
        public void Valid_Interface_Detailed()
        {
            if (CommandHelp == null)
                return;
            Assert.IsFalse(string.IsNullOrWhiteSpace(CommandHelp.Detailed), "CommandHelp.Detailed IsNullOrWhiteSpace");
        }

        [TestMethod]
        public void Valid_Interface_Name()
        {
            if (CommandHelp == null)
                return;
            Assert.IsFalse(string.IsNullOrWhiteSpace(CommandHelp.Name), "CommandHelp.Name IsNullOrWhiteSpace");
        }

        [TestMethod]
        public void Valid_Interface_Usage()
        {
            if (CommandHelp == null)
                return;
            Assert.IsFalse(string.IsNullOrWhiteSpace(CommandHelp.Usage), "CommandHelp.Usage IsNullOrWhiteSpace");
        }

        [TestMethod]
        public void Valid_Interface_Options()
        {
            if (CommandHelp == null)
                return;
            Assert.IsNotNull(CommandHelp.Options, "CommandHelp.Options == null");
        }

        [TestMethod]
        public void Valid_Interface_Options_Count()
        {
            if (CommandHelp == null)
                return;
            Assert.IsTrue(CommandHelp.Options.Count > 0, "CommandHelp.Options.Count == 0");
        }

        [TestMethod]
        public void Valid_Interface_Options_Count_Enumeration()
        {
            if (CommandHelp == null)
                return;
            var count = CommandHelp.Options.Count;
            for (var ac = 0; ac < count; ++ac)
            {
                var dds = (Pingo.CommandLine.Contracts.Help.IOptionHelp) CommandHelp.Options.GetByIndex(ac);

                Assert.IsFalse(string.IsNullOrWhiteSpace(dds.Description), "dds.Description IsNullOrWhiteSpace");
                Assert.IsFalse(string.IsNullOrWhiteSpace(dds.Name), "dds.Name IsNullOrWhiteSpace");
                Assert.IsFalse(string.IsNullOrWhiteSpace(dds.Usage), "dds.Usage IsNullOrWhiteSpace");
            }
        }
    }
}