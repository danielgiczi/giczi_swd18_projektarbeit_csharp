using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class DijkstraAlgorithmTests
    {
        [TestMethod]
        public void Test()
        {
            string chosenMap = "S 0 0 -5 D";
            var map = new Map(chosenMap);
            var algorithm = new DijkstraAlgorithm(map.StartX, map.StartY, map.DestX, map.DestY, chosenMap);

            var result = algorithm.run();

            Assert.AreEqual(4, result.Probes.Count);
            Assert.AreEqual(5, result.Paths.Count);
        }

        [TestMethod]
        public void Test2()
        {
            string chosenMap = @"S 8 D
                                 0 0 0";

            var map = new Map(chosenMap);
            var algorithm = new DijkstraAlgorithm(map.StartX, map.StartY, map.DestX, map.DestY, chosenMap);

            var result = algorithm.run();  

            Assert.AreEqual(2, result.Paths[0].X);
            Assert.AreEqual(0, result.Paths[0].Y);

            Assert.AreEqual(2, result.Paths[1].X);
            Assert.AreEqual(1, result.Paths[1].Y);

            Assert.AreEqual(1, result.Paths[2].X);
            Assert.AreEqual(1, result.Paths[2].Y);

            Assert.AreEqual(0, result.Paths[3].X);
            Assert.AreEqual(1, result.Paths[3].Y);
        }
    }
}
