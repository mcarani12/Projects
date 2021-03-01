using System;
using HomeAssignmentOOP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessWhoTest
{
    [TestClass]
    public class UnitTest1
    {
        Person p = new Person("Bill", false, "brown", 'm');

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(p);
        }
        
        [TestMethod]
        public void TestMethod2()
        {
            bool expected = false;
            bool actual = p.Hat;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Game g = new Game(p);

            Assert.AreEqual(g.Person, p);
        }

        [TestMethod]
        public void TestMethod4()
        {
            SimpleGuessingGame s = new SimpleGuessingGame(p);

            Assert.IsInstanceOfType(s, typeof(Game));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Person p = new Person("Bill", false, "brown", 'a');
            Assert.AreEqual(p.Gender, 'm');
        }
    }
}
