using Json2Xml.Core.Versioning;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Json2Xml.Core.Tests.Versioning
{
    [TestClass]
    public class IntervalVersioningTests
    {
        [TestMethod]
        public void TestLockedDownVersion()
        {

            var res1 = new IntervalNotationVersioning("[1.2.3]");
            Assert.IsNotNull(res1);
            Assert.IsTrue(0 == res1.Compare("1.2.3"));
            Assert.IsFalse(0 == res1.Compare("1.2.2"));
            Assert.IsFalse(0 == res1.Compare("1.2.4"));
            
            var set = res1.HasFlag(RangeDisposition.LowerAndUpperMatch);
            Assert.IsTrue(set);
        }

        [TestMethod]
        public void TestIncludeRange()
        {


            var res1 = new IntervalNotationVersioning("[1.2.3,4]");
            Assert.IsNotNull(res1);

            Assert.IsFalse(0 == res1.Compare("1"));
            Assert.IsFalse(0 == res1.Compare("1.2"));
            Assert.IsFalse(0 == res1.Compare("1.2.2"));
            Assert.IsTrue(0 == res1.Compare("1.2.3"));
            Assert.IsTrue(0 == res1.Compare("1.2.4"));
            Assert.IsTrue(0 == res1.Compare("2"));
            Assert.IsTrue(0 == res1.Compare("2.2"));
            Assert.IsTrue(0 == res1.Compare("2.2.2"));
            Assert.IsTrue(0 == res1.Compare("2.2.2.2"));
            Assert.IsTrue(0 == res1.Compare("3"));
            Assert.IsTrue(0 == res1.Compare("3.3"));
            Assert.IsTrue(0 == res1.Compare("3.3.3"));
            Assert.IsTrue(0 == res1.Compare("3.3.3.3"));
            Assert.IsTrue(0 == res1.Compare("4"));
            Assert.IsFalse(0 == res1.Compare("4.1"));

            var set = res1.HasFlag(RangeDisposition.LowerAndUpperMatch);
            Assert.IsFalse(set);
        }

        [TestMethod]
        public void TestLowerExcludeRange()
        {
            var res1 = new IntervalNotationVersioning("(1,4]");
            Assert.IsNotNull(res1);

            Assert.IsFalse(0 == res1.Compare("1"));
            Assert.IsTrue(0 == res1.Compare("1.2"));
            Assert.IsTrue(0 == res1.Compare("1.2.2"));
            Assert.IsTrue(0 == res1.Compare("1.2.3"));
            Assert.IsTrue(0 == res1.Compare("1.2.4"));
            Assert.IsTrue(0 == res1.Compare("2"));
            Assert.IsTrue(0 == res1.Compare("2.2"));
            Assert.IsTrue(0 == res1.Compare("2.2.2"));
            Assert.IsTrue(0 == res1.Compare("2.2.2.2"));
            Assert.IsTrue(0 == res1.Compare("3"));
            Assert.IsTrue(0 == res1.Compare("3.3"));
            Assert.IsTrue(0 == res1.Compare("3.3.3"));
            Assert.IsTrue(0 == res1.Compare("3.3.3.3"));
            Assert.IsTrue(0 == res1.Compare("4"));
            Assert.IsFalse(0 == res1.Compare("4.1"));

            var set = res1.HasFlag(RangeDisposition.LowerAndUpperMatch);
            Assert.IsFalse(set);
        }

        [TestMethod]
        public void TestUpperExcludeRange()
        {
            var res1 = new IntervalNotationVersioning("[1,4)");
            Assert.IsNotNull(res1);

            Assert.IsFalse(0 == res1.Compare("0.1"));
            Assert.IsTrue(0 == res1.Compare("1"));
            Assert.IsTrue(0 == res1.Compare("1.2"));
            Assert.IsTrue(0 == res1.Compare("1.2.2"));
            Assert.IsTrue(0 == res1.Compare("1.2.3"));
            Assert.IsTrue(0 == res1.Compare("1.2.4"));
            Assert.IsTrue(0 == res1.Compare("2"));
            Assert.IsTrue(0 == res1.Compare("2.2"));
            Assert.IsTrue(0 == res1.Compare("2.2.2"));
            Assert.IsTrue(0 == res1.Compare("2.2.2.2"));
            Assert.IsTrue(0 == res1.Compare("3"));
            Assert.IsTrue(0 == res1.Compare("3.3"));
            Assert.IsTrue(0 == res1.Compare("3.3.3"));
            Assert.IsTrue(0 == res1.Compare("3.3.3.3"));
            Assert.IsFalse(0 == res1.Compare("4"));
            Assert.IsFalse(0 == res1.Compare("4.1"));

            var set = res1.HasFlag(RangeDisposition.LowerAndUpperMatch);
            Assert.IsFalse(set);
        }
    }
}
