using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Schema;

namespace Algorithms
{
    public class DijkstraNode
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DijkstraNode Parent { get; set; }
        public int Distance { get; set; } = int.MaxValue;
        public List<DijkstraNode> Adjacents { get; set; } = new List<DijkstraNode>();
        public bool Selected { get; set; }
        public int Weight { get; set; }

        public DijkstraNode(int x, int y)
        {
            X = x;
            Y = y;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override bool Equals(object obj)
        {
            return obj is DijkstraNode node &&
                   X == node.X &&
                   Y == node.Y;
        }

        public override string ToString()
        {
            return $"{X}|{Y}";
        }
    }

    public class DijkstraAlgorithm : IAlgorithm
    {
        private DijkstraNode P;
        private DijkstraNode G;
        private DijkstraGraph graph;

        public DijkstraAlgorithm(int startX, int startY, int goalX, int goalY, string rawData)
        {
            P = new DijkstraNode(startX, startY);
            G = new DijkstraNode(goalX, goalY);
            graph = new DijkstraGraph(new Map(rawData));
        }

        public AlgorithmResult run()
        {
            var result = new AlgorithmResult();
            graph.reset();
            graph.Get(P.X, P.Y).Distance = 0;

            while (true)
            {
                var UnexploredList = graph.GetSortedUnexploredList();
                if (UnexploredList.Count == 0)
                {
                    break;
                }

                var B = UnexploredList.FirstOrDefault();
                B.Selected = true;

                if (B.Equals(G))
                {
                    var node = B;
                    var nextNode = node.Parent;
                    while (node.Parent != null)
                    {
                        result.Paths.Add(new Paths(node.X, node.Y));
                        node = nextNode;
                        nextNode = node.Parent;
                    }

                    if (B.Parent != null)
                    {
                        result.Paths.Add(new Paths(node.X, node.Y));
                    }

                    break;
                }


                var adjacentNodes = B.Adjacents;

                for (var adjacentNodeIndex = 0; adjacentNodeIndex < adjacentNodes.Count; adjacentNodeIndex++)
                {
                    var C = adjacentNodes[adjacentNodeIndex];
                    if (C.Selected)
                    {
                        continue;
                    }

                    if (C.Weight != int.MaxValue)
                    {
                        result.Probes.Add(new Probes(C.X, C.Y));
                    }

                    var distance = (B.Distance == int.MaxValue ? 0 : B.Distance) + C.Weight + 1;

                    if(C.Weight == int.MaxValue)
                    {
                        distance = int.MaxValue;
                    }

                    if (distance < C.Distance)
                    {
                        C.Distance = distance;
                        C.Parent = B;
                    }
                }
            }

            return result;
        }
    }
}
