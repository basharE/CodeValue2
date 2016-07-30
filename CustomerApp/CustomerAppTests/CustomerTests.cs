using CustomerApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerAppTests
{
    [TestClass()]
    public class CustomerTests
    {

        [TestMethod()]
        public void CompareToTestNull()
        {
            Customer c = new Customer("sam",33);
            Assert.AreEqual(c.CompareTo(null),1);
        }

        [TestMethod()]
        public void CompareToTestFLower()
        {
            Customer c = new Customer("sAM", 33);
            Assert.AreEqual(c.CompareTo(new Customer("sam", 33)), 0);
        }

        [TestMethod()]
        public void CompareToTestSLower()
        {
            Customer c = new Customer("sam", 33);
            Assert.AreEqual(c.CompareTo(new Customer("SaM", 33)), 0);
        }

        [TestMethod()]
        public void CompareToTestBLower()
        {
            Customer c = new Customer("SAM", 33);
            Assert.AreEqual(c.CompareTo(new Customer("SaM", 33)), 0);
        }

        [TestMethod()]
        public void CompareToTestNLower()
        {
            Customer c = new Customer("sam", 33);
            Assert.AreEqual(c.CompareTo(new Customer("sam", 33)), 0);
        }

        [TestMethod()]
        public void CompareToTestF()
        {
            Customer c = new Customer("s", 33);
            Assert.AreEqual(c.CompareTo(new Customer("sam", 33)), -1);
        }

        [TestMethod()]
        public void CompareToTestS()
        {
            Customer c = new Customer("sam", 33);
            Assert.AreEqual(c.CompareTo(new Customer("s", 33)), 1);
        }

        [TestMethod()]
        public void EqualsTestDifIdDifName()
        {
            Customer c1 = new Customer("sam", 33);
            Customer c2 = new Customer("jon", 34);
            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod()]
        public void EqualsTestSameIdDifName()
        {
            Customer c1 = new Customer("sam", 34);
            Customer c2 = new Customer("jon", 34);
            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod()]
        public void EqualsTestDifIdSameName()
        {
            Customer c1 = new Customer("sam", 33);
            Customer c2 = new Customer("sam", 34);
            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod()]
        public void EqualsTestSameIdSameName()
        {
            Customer c1 = new Customer("SAM", 33);
            Customer c2 = new Customer("sam", 33);
            Assert.IsTrue(c1.Equals(c2));
        }

        [TestMethod()]
        public void EqualsTestNull()
        {
            Customer c1 = new Customer("SAM", 33);           
            Assert.IsFalse(c1.Equals(null));
        }
    }
}