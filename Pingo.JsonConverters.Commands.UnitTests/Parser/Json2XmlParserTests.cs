using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;
using Pingo.JsonConverters.Commands.Commands;

namespace Pingo.JsonConverters.Commands.UnitTests.Parser
{
    [TestClass]
    public class Json2XmlParserTests
    {
        public string[] ArgsTemplate = new string[] {"-s", @"c:\path\to\source.json", "-o", @"c:\path\to\output.xml"};
        public string[] SchemaTemplate = new string[] { "-source", @"c:\path\to\source.json", "-Schema", @"c:\path\to\output.xml" };

        public string[][] ValidTestArguments = new string[][]
        {
            new string[] {"-s", @"c:\path\to\source.json", "-o", @"c:\path\to\output.xml"},
            new string[] {"-s", @"c:\path\to\source.json", "-Output", @"c:\path\to\output.xml"},
            new string[] {"-source", @"c:\path\to\source.json", "-o", @"c:\path\to\output.xml"},
            new string[] {"-Source", @"c:\path\to\source.json", "-Output", @"c:\path\to\output.xml"},
            new string[] {"-Source", @"c:\path\to\source.json", "-Output", @"c:\path\to\output.xml","-Straglers", @"Who am I"}
        };

        public string[][] InValidTestArguments = new string[][]
        {
            new string[] {"-D", @"c:\path\to\source.json", "-o", @"c:\path\to\output.xml"},
            new string[] {"-Dource", @"c:\path\to\source.json", "-Output", @"c:\path\to\output.xml"},
            new string[] {"-Dource", @"c:\path\to\source.json", "-Output", @"c:\path\to\output.xml","-Straglers", @"Who am I"}
        };

        public string[][] ValidTestArgumentsForJsonSchema = new string[][]
        {
            new string[] {"-s", @"c:\path\to\source.json", "-Schema", @"c:\path\to\schema.json"},
            new string[] {"-Source", @"c:\path\to\source.json", "-Schema", @"c:\path\to\schema.json","-Straglers", @"Who am I"}
        };

        [TestMethod]
        public void Valid_Arguments_Passed_To_Json2XmlParser()
        {
            foreach (var testArg in ValidTestArguments)
            {
                var parser = new Pingo.JsonConverters.Commands.Parser.Json2XmlArgumentParser();
                parser.Parse(testArg);
                Assert.IsTrue(System.String.Compare(@"c:\path\to\source.json", parser.SourcePath, System.StringComparison.OrdinalIgnoreCase)==0);
                Assert.IsTrue(System.String.Compare(@"c:\path\to\output.xml", parser.OutputPath, System.StringComparison.OrdinalIgnoreCase) == 0);
            }
        }

        [TestMethod]
        public void Valid_Arguments_Passed_To_JsonSchemaArgumentParser()
        {
            foreach (var testArg in ValidTestArgumentsForJsonSchema)
            {
                var parser = new Pingo.JsonConverters.Commands.Parser.JsonSchemaArgumentParser();
                parser.Parse(testArg);
                Assert.IsTrue(System.String.Compare(@"c:\path\to\source.json", parser.SourcePath, System.StringComparison.OrdinalIgnoreCase) == 0);
                Assert.IsTrue(System.String.Compare(@"c:\path\to\schema.json", parser.SourceSchema, System.StringComparison.OrdinalIgnoreCase) == 0);
            }
        }

        [TestMethod]
        public void Invalid_Arguments_Passed_To_Json2XmlArgumentParser()
        {
            foreach (var testArg in InValidTestArguments)
            {
                var parser = new Pingo.JsonConverters.Commands.Parser.Json2XmlArgumentParser();

                MSTestExtensions.ThrowsAssert.Throws(() => { parser.Parse(testArg); });
            }
        }

        [TestMethod]
        public void Invalid_Arguments_Passed_To_JsonSchemaArgumentParser()
        {
            foreach (var testArg in InValidTestArguments)
            {
                var parser = new Pingo.JsonConverters.Commands.Parser.JsonSchemaArgumentParser();

                MSTestExtensions.ThrowsAssert.Throws(() => { parser.Parse(testArg); });
            }
        }

        [TestMethod]
        public void Invalid_Arguments_Passed_To_Json2XmlCommand()
        {
            foreach (var testArg in InValidTestArguments)
            {
                var command = new Json2XmlCommand();
                var result = command.ExecuteCommand(testArg);
                Assert.IsTrue(result.HasErrors);
            }
        }
        [TestMethod]
        public void Invalid_Arguments_Passed_To_Xml2JsonCommand()
        {
            foreach (var testArg in InValidTestArguments)
            {
                var command = new Xml2JsonCommand();
                var result = command.ExecuteCommand(testArg);
                Assert.IsTrue(result.HasErrors);
            }
        }

        [TestMethod]
        public void Invalid_Arguments_Passed_To_JsonSchemaCommand()
        {
            foreach (var testArg in InValidTestArguments)
            {
                var command = new JsonSchemaCommand();
                var result = command.ExecuteCommand(testArg);
                Assert.IsTrue(result.HasErrors);
            }
        }
        [TestMethod]
        [DeploymentItem(@"TestData\",@"TestData\")]
        public void Nuspec_To_Json_Success()
        {
            Assert.IsTrue(File.Exists("TestData\\Package.nuspec"));
            var fi = new FileInfo("TestData\\Package.nuspec");
            
            var args = (string[]) ArgsTemplate.Clone();
            args[1] = fi.FullName;
            args[3] = Path.Combine(fi.Directory.FullName,"Result\\Package.json");

            var command = new Xml2JsonCommand();
            var result = command.ExecuteCommand(args);

            Assert.IsFalse(result.HasErrors);

            var argsSchema = (string[])SchemaTemplate.Clone();
            argsSchema[1] = args[3];
            argsSchema[3] = Path.Combine(fi.Directory.FullName, "Package.Schema.json");

            var commandSchema = new JsonSchemaCommand();
            result = commandSchema.ExecuteCommand(argsSchema);
            Assert.IsFalse(result.HasErrors);
        }

        [TestMethod]
        [DeploymentItem(@"TestData\", @"TestData\")]
        public void Json_to_Nuspec_Success()
        {
            Assert.IsTrue(File.Exists("TestData\\Package.nuspec"));
            var fi = new FileInfo("TestData\\Package.nuspec");

            var args = (string[])ArgsTemplate.Clone();
            args[1] = fi.FullName;
            args[3] = Path.Combine(fi.Directory.FullName, "Result\\Package.json");

            var command = new Xml2JsonCommand();
            var result = command.ExecuteCommand(args);

            Assert.IsFalse(result.HasErrors);

            args[1] = Path.Combine(fi.Directory.FullName, "Result\\Package.json");
            args[3] = Path.Combine(fi.Directory.FullName, string.Format("Result\\{0}.nuspec",Guid.NewGuid().ToString()));


            var command3 = new Json2XmlCommand();
            result = command3.ExecuteCommand(args);

            Assert.IsFalse(result.HasErrors);
        }

        [TestMethod]
        [DeploymentItem("TestData\\", "TestData\\")]
        public void Json_Schema_Validation_Success()
        {
            Assert.IsTrue(File.Exists("TestData\\Package.nuspec"));
            var fi = new FileInfo("TestData\\Package.json");



            var argsSchema = (string[])SchemaTemplate.Clone();
            argsSchema[1] = fi.FullName;
            argsSchema[3] = Path.Combine(fi.Directory.FullName, "Package.Schema.json");

            var commandSchema = new JsonSchemaCommand();
            var result = commandSchema.ExecuteCommand(argsSchema);
            Assert.IsFalse(result.HasErrors);
        }

        [TestMethod]
        [DeploymentItem("TestData\\", "TestData\\")]
        public void Json_Schema_Validation_Fail()
        {
            Assert.IsTrue(File.Exists("TestData\\Package.nuspec"));
            var fi = new FileInfo("TestData\\Package.json");



            var argsSchema = (string[])SchemaTemplate.Clone();
            argsSchema[1] = fi.FullName;
            argsSchema[3] = Path.Combine(fi.Directory.FullName, "ChromeExtension.Schema.json");

            var commandSchema = new JsonSchemaCommand();
            var result = commandSchema.ExecuteCommand(argsSchema);
            Assert.IsTrue(result.HasErrors);
        }
    }
}
