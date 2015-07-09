using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pingo.JsonConverters.Commands.Commands;
using Pingo.JsonConverters.Commands.Executables;
using Pingo.JsonConverters.Commands.UnitTests.Help;

namespace Pingo.JsonConverters.Commands.UnitTests.Executables
{
    [TestClass]
    public class Xml2JsonExecutableTests : CommandHelpTests
    {
        public string[] ArgsTemplate = new string[] { "-s", @"c:\path\to\source.json", "-o", @"c:\path\to\output.xml" };
 
        [TestMethod]
        public void Failed_Bad_SourceSchema()
        {
            var executable = new Xml2JsonExecutable() { Source = null };
            var result = executable.Execute();
            Assert.IsTrue(result.HasErrors);
        }

        [TestMethod]
        [DeploymentItem(@"TestData\", @"TestData\")]
        public void Failed_Bad_Output()
        {
            Assert.IsTrue(File.Exists("TestData\\Package.nuspec"));
            var fi = new FileInfo("TestData\\Package.nuspec");

            var args = (string[])ArgsTemplate.Clone();
            args[1] = fi.FullName;
            args[3] = Path.Combine(fi.Directory.FullName, "Result\\Package.json");

            var command = new Xml2JsonCommand();
            var result = command.ExecuteCommand(args);

            Assert.IsFalse(result.HasErrors);

            var executable = new Json2XmlExecutable { Source = args[3] ,Output = null};

            var result3 = executable.Execute();
            Assert.IsTrue(result3.HasErrors);
        }
    }
}
