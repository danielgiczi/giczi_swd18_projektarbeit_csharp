using Algorithms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class AStarAlgorithmTests
    {
        [TestMethod]
        public void Test()
        {
            string chosenMap = @"S 8 D
                                 0 0 0";

            var map = new Map(chosenMap);
            var algorithm = new AStarAlgorithm(map.StartX, map.StartY, map.DestX, map.DestY, chosenMap);

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

        [TestMethod]
        public void Test2()
        {
            string chosenMap = @"
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 S 0 0 0 0 0 0 0 0 0 0 0 0 0 D
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
";

            var map = new Map(chosenMap);
            var algorithm = new AStarAlgorithm(map.StartX, map.StartY, map.DestX, map.DestY, chosenMap);

            var result = algorithm.run();


            result.Paths[0].NodeEquals(21, 10);
            result.Paths[1].NodeEquals(20, 10);
            result.Paths[2].NodeEquals(19, 10);
            result.Paths[3].NodeEquals(18, 10);
            result.Paths[4].NodeEquals(17, 10);
            result.Paths[5].NodeEquals(16, 10);
            result.Paths[6].NodeEquals(15, 10);

            result.Probes[0].NodeEquals(7, 9);
            result.Probes[4].NodeEquals(8,9);
            result.Probes[15].NodeEquals(11,10);
        }
    }

    public static class MyExtensions
    {
        public static void NodeEquals(this Paths path, int x,int y)
        {
            Assert.AreEqual(x, path.X);
            Assert.AreEqual(y, path.Y);
        }

        public static void NodeEquals(this Probes path, int x, int y)
        {
            Assert.AreEqual(x, path.X);
            Assert.AreEqual(y, path.Y);
        }
    }
}
