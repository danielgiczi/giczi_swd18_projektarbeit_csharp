using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class MapTests
    {
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Test_ThrowsException()
        {
            new Map("");
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Test_ThrowsException2()
        {
            new Map("S 0 0 0");
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Test_ThrowsException3()
        {
            new Map("0 0 0 D");
        }

        [TestMethod]
        public void Test_Correct()
        {
            var map = new Map("S 0 0 D");
            Assert.AreEqual(0, map.StartX);
            Assert.AreEqual(0, map.StartY);
            Assert.AreEqual(3, map.DestX);
            Assert.AreEqual(0, map.DestY);
        }

    }
}
