using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;
using Pingo.CommandLine.Fluent;

namespace Pingo.CommandLine.Tests
{
    [TestClass]
    public class CommandLineOptionHelpContainerUnitTest
    {
        private const string Key1 = "Key1";
        private const string Key2 = "Key2";
        private const string Description = "Some Description";
        private const string ShortName1 = "ShortName1";
        private const string ShortName2 = "ShortName2";

        private const string LongName1 = "LongName1";
        private const string LongName2 = "LongName2";


        [TestMethod]
        public void Test_AddStepByStepEntry()
        {
            var helpContainer = new CommandLineOptionHelpContainer();
            Assert.IsNotNull(helpContainer);

            var option = helpContainer.Setup(Key1,ShortName1,LongName1);
            Assert.IsNotNull(option);

            option = option.SetDescription(Description);
            Assert.IsNotNull(option);

            Assert.IsFalse(option.IsRequired);
            option = option.Required();

            Assert.IsNotNull(option);
            Assert.IsTrue(option.IsRequired);

            Assert.IsTrue(0 == System.String.Compare(ShortName1, option.ShortName, System.StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(0 == System.String.Compare(LongName1, option.LongName, System.StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(0 == System.String.Compare(Description, option.Description, System.StringComparison.OrdinalIgnoreCase));

            option.SetLongName(LongName2)
                .SetShortName(ShortName2);
            Assert.IsTrue(0 == System.String.Compare(ShortName2, option.ShortName, System.StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(0 == System.String.Compare(LongName2, option.LongName, System.StringComparison.OrdinalIgnoreCase));


        }

        [TestMethod]
        public void Test_AddFluentEntry()
        {
            var helpContainer = new CommandLineOptionHelpContainer();
            Assert.IsNotNull(helpContainer);

           var option = helpContainer.Setup(Key1,ShortName2,LongName2)
                .SetDescription(Description)
                .SetLongName(LongName1)
                .SetShortName(ShortName1);
            Assert.IsFalse(option.IsRequired);
            Assert.IsTrue(0 == System.String.Compare(ShortName1, option.ShortName, System.StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(0 == System.String.Compare(LongName1, option.LongName, System.StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(0 == System.String.Compare(Description, option.Description, System.StringComparison.OrdinalIgnoreCase));

            ThrowsAssert.Throws(() =>
            {
                option = helpContainer.Setup(Key1, ShortName2, LongName2)
                    .SetDescription(Description)
                    .SetLongName(LongName2)
                    .SetShortName(ShortName2)
                    .Required();
            });

            option = helpContainer.Setup(Key2, ShortName2, LongName2)
                .SetDescription(Description)
                .SetLongName(LongName2)
                .SetShortName(ShortName2)
                .Required();


            Assert.IsTrue(option.IsRequired);
            Assert.IsTrue(0 == System.String.Compare(ShortName2, option.ShortName, System.StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(0 == System.String.Compare(LongName2, option.LongName, System.StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(0 == System.String.Compare(Description, option.Description, System.StringComparison.OrdinalIgnoreCase));

        }
    }
}
