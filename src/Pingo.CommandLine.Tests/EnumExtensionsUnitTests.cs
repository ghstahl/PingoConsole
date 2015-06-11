using System;
using System.CodeDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;
using Pingo.CommandLine.Enum;

namespace Pingo.CommandLine.Tests
{
    [TestClass]
    public class EnumExtensionsUnitTests
    {

        [Flags]
        private enum AnEmptyEnum

        {

        }

        [Flags]
        private enum OneEntry
        {
            One = 1
        }
        [Flags]
        private enum TwoEntry
        {
            One = 1,
            Two = 2
        }

        [TestMethod]
        public void TestBang()
        {

            var result = typeof(AnEmptyEnum).ToBangEnum();
            Assert.IsTrue(string.IsNullOrWhiteSpace(result));

            result = typeof(TwoEntry).ToBangEnum();
            Assert.IsTrue(0 == System.String.Compare(result, "One|Two", System.StringComparison.OrdinalIgnoreCase));

            result = typeof(OneEntry).ToBangEnum();
            Assert.IsTrue(0 == System.String.Compare(result, "One", System.StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestToFirstEnum()
        {
            ThrowsAssert.Throws(() =>
            {
                typeof(AnEmptyEnum).ToFirstEnum();
            });

            var result = typeof(TwoEntry).ToFirstEnum();
            Assert.IsTrue(0 == System.String.Compare(result, "One", System.StringComparison.OrdinalIgnoreCase));

            result = typeof(OneEntry).ToFirstEnum();
            Assert.IsTrue(0 == System.String.Compare(result, "One", System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
