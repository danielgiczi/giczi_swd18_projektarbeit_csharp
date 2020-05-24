using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;

namespace Tests
{
    [TestClass]
    public class DijkstraGraphTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            string chosenMap = "S 0 0 -5 D";
            var graph = new DijkstraGraph(new Map(chosenMap));

            Assert.AreEqual(0, graph.Nodes["0|0"].Weight);
            Assert.AreEqual(5, graph.Nodes["3|0"].Weight);
        }

        [TestMethod]
        public void TestConstructorAdjacents()
        {
            string chosenMap = "S 0 0 -5 D";
            var graph = new DijkstraGraph(new Map(chosenMap));

            Assert.AreEqual(1, graph.Get(0, 0).Adjacents.Count);
            Assert.AreEqual(graph.Get(0, 0).Adjacents.First(), graph.Get(1, 0));
        }

        [TestMethod]
        public void TestConstructorAdjacents2()
        {
            string chosenMap =  @"
                                  S 0 0 0 D
                                  0 0 0 0 0
                                  0 0 0 0 0";

            var graph = new DijkstraGraph(new Map(chosenMap));

            Assert.AreEqual(2, graph.Get(0, 0).Adjacents.Count);

            Assert.AreEqual(4, graph.Get(2, 1).Adjacents.Count);

        }

        [TestMethod]
        public void Test_GetSortedUnexploredList()
        {
            string chosenMap = @"
                                  S 0 0 0 D
                                  0 0 0 0 0
                                  0 0 0 0 0";

            var graph = new DijkstraGraph(new Map(chosenMap));


            var unexplored = graph.GetSortedUnexploredList();

            Assert.AreEqual(15, unexplored.Count);

            graph.Get(2, 1).Selected = true;

            unexplored = graph.GetSortedUnexploredList();

            Assert.AreEqual(14, unexplored.Count);

            graph.reset();
            
            unexplored = graph.GetSortedUnexploredList();

            Assert.AreEqual(15, unexplored.Count);
        }

        [TestMethod]
        public void Test_GetSortedUnexploredListSorting()
        {
            string chosenMap = @"
                                  S 0 0 0 D
                                  0 0 0 0 0
                                  0 0 0 0 0";

            var graph = new DijkstraGraph(new Map(chosenMap));


            graph.Get(3, 2).Distance = 5;
            graph.Get(0, 2).Distance = 3;
            graph.Get(2, 0).Distance = 2;

            var unexplored = graph.GetSortedUnexploredList();

            Assert.AreEqual(graph.Get(2, 0), unexplored[0]);
            Assert.AreEqual(graph.Get(0, 2), unexplored[1]);
            Assert.AreEqual(graph.Get(3, 2), unexplored[2]);
        }
    }
}
