using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pingo.JsonConverters.Commands.Executables;
using Pingo.JsonConverters.Commands.UnitTests.Help;

namespace Pingo.JsonConverters.Commands.UnitTests.Executables
{
    [TestClass]
    public class JsonSchemaExecutableTests : CommandHelpTests
    {
        [TestMethod]
        public void Failed_Bad_SourceSchema()
        {
            var executable = new JsonSchemaExecutable {SourceSchema = null};
            var result = executable.Execute();
            Assert.IsTrue(result.HasErrors);
        }

        [TestMethod]
        [DeploymentItem(@"TestData\", @"TestData\")]
        public void Failed_Bad_Source()
        {
            Assert.IsTrue(File.Exists("TestData\\Package.nuspec"));
            var fi = new FileInfo("TestData\\Package.json");
            var goodSchema = Path.Combine(fi.Directory.FullName, "Package.Schema.json");

            var executable = new JsonSchemaExecutable {SourceSchema = goodSchema, Source = null};

            var result = executable.Execute();
            Assert.IsTrue(result.HasErrors);

        }
    }
}
