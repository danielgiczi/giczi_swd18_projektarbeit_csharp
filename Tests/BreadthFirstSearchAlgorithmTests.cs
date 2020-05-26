using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class BreadthFirstSearchAlgorithmTests
    {
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
    0 0 0 0 D 0 0 0 0 0 0 0 0 0 0 0 0 S 0 0 0 0
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
            var algorithm = new BreadthFirstSearchAlgorithm(map.StartX, map.StartY, map.DestX, map.DestY, chosenMap);

            var sw = System.Diagnostics.Stopwatch.StartNew();
            var result = algorithm.run();

            sw.Stop(); 
            Assert.IsTrue(sw.ElapsedMilliseconds < 100);
            System.Diagnostics.Debug.WriteLine("Elapsed: " + sw.ElapsedMilliseconds);

            result.Paths[0].NodeEquals(4, 10);

            result.Paths[1].NodeEquals(5, 10);
            result.Paths[2].NodeEquals(6, 10);
            result.Paths[3].NodeEquals(7, 10);
            result.Paths[4].NodeEquals(8, 10);
            result.Paths[5].NodeEquals(9, 10);
            result.Paths[6].NodeEquals(10, 10); 
            result.Paths[7].NodeEquals(11, 10);
            result.Paths[8].NodeEquals(12, 10);
            result.Paths[9].NodeEquals(13, 10);
            result.Paths[10].NodeEquals(14, 10);
            result.Paths[11].NodeEquals(15, 10);
            result.Paths[12].NodeEquals(16, 10);
            result.Paths[13].NodeEquals(17, 10);
        }
    }
}
