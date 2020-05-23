using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;

namespace Tests
{
    [TestClass]
    public class InvokerTests
    {
        [TestMethod]
        public void BreadthFirstTest()
        {
            var data = new InvokerData();
            data.AlgorithmIndex = 2;
            data.StartX = 0;
            data.StartY = 0;
            data.DestX = 5;
            data.DestY = 0;
            data.MapData = "S 0 0 0 0 D";


            var result = AlgorithmInvoker.Invoke(data);

            Assert.AreEqual(true, result.Found);
            Assert.AreEqual(6, result.Paths.Count);
            Assert.AreEqual(4, result.Probes.Count);

            Assert.AreEqual(1, result.Probes[0].X);
            Assert.AreEqual(0, result.Probes[0].Y);

            Assert.AreEqual(2, result.Probes[1].X);
            Assert.AreEqual(0, result.Probes[1].Y);

            Assert.AreEqual(3, result.Probes[2].X);
            Assert.AreEqual(0, result.Probes[2].Y);

            Assert.AreEqual(4, result.Probes[3].X);
            Assert.AreEqual(0, result.Probes[3].Y);

            Assert.AreEqual(5, result.Paths[0].X);
            Assert.AreEqual(0, result.Paths[0].Y);

            Assert.AreEqual(5, result.Paths[0].X);
            Assert.AreEqual(0, result.Paths[0].Y);
        }
    }
}
