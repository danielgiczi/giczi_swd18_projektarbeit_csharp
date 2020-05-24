using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Algorithms
{
    public class AStarNode
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int F { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public AStarNode Parent { get; set; }

        public AStarNode(int x, int y)
        {
            X = x;
            Y = y;

            F = 0;
            G = 0;
            H = 0;
            Parent = null;
        }

        public override bool Equals(object obj)
        {
            return obj is AStarNode node &&
                   X == node.X &&
                   Y == node.Y;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }

    public class AStarAlgorithm : IAlgorithm
    {
        private AStarNode P;
        private AStarNode G;
        private Map map;

        public AStarAlgorithm(int startX, int startY, int goalX, int goalY, string rawData) 
        {
            P = new AStarNode(startX, startY);
            G = new AStarNode(goalX, goalY);
            map = new Map(rawData);
        }

        private int GetCostFromStartToNode(AStarNode node)
        {
            return Math.Abs(G.X - node.X) + Math.Abs(G.Y - node.Y);
        }

        private int GetEstimatedCostFromStartToNode(AStarNode node)
        {
            if (node.Parent == null)
            {
                return 0;
            }

            return node.Parent.G + map.GetCoordCost(node.X, node.Y) + 1;
        }

        public AlgorithmResult run()
        {
            var OpenList = new List<AStarNode>() { P };
            var ClosedList = new List<AStarNode>();

            var result = new AlgorithmResult();

            while (true)
            {
                if (OpenList.Count == 0)
                {
                    break;
                }

                OpenList = OpenList.OrderBy(x => x.F).ToList();
                var B = OpenList.FirstOrDefault();
                OpenList.RemoveAt(0);
                ClosedList.Add(B);

                var connectedNodes = GetConnectedNodes(B);
                connectedNodes = connectedNodes.OrderBy(x => x.F).ToList();

                var breakWhile = false;
                for (var childIndex = 0; childIndex < connectedNodes.Count; childIndex++)
                {
                    var C = connectedNodes[childIndex];
                    CalculateCostsForNode(C);

                    var nodeInOpenList = OpenList.FirstOrDefault(x => x.Equals(C));
                    var nodeInClosedList = ClosedList.FirstOrDefault(x => x.Equals(C));

                    result.Probes.Add(new Probes(C.X, C.Y));

                    if (C.Equals(G))
                    {
                        var node = C;
                        var nextNode = node.Parent;
                        while (node.Parent != null)
                        {
                            result.Paths.Add(new Paths(node.X, node.Y));
                            node = nextNode;
                            nextNode = node.Parent;
                        }

                        result.Paths.Add(new Paths(node.X, node.Y));
                        breakWhile = true;
                        break;
                    }
                    else if (nodeInOpenList != null)
                    {
                        if (C.F >= nodeInOpenList.F)
                        {
                            continue;
                        }
                    }

                    else if (nodeInClosedList != null)
                    {
                        if (C.F >= nodeInClosedList.F)
                        {
                            continue;
                        }
                        else
                        {
                            OpenList.Add(C);
                        }
                    }
                    else
                    {
                        OpenList.Add(C);
                    }
                }
                if (breakWhile) break;
            }

            return result;
        }

        private void CalculateCostsForNode(AStarNode node)
        {
            node.G = GetEstimatedCostFromStartToNode(node);
            node.H = GetCostFromStartToNode(node);
            node.F = node.G + node.H;
        }

        private List<AStarNode> GetConnectedNodes(AStarNode parent)
        {
            var nodes = new List<AStarNode>();

            //above
            if (map.IsValidCoord(parent.X, parent.Y - 1))
            {
                var node = new AStarNode(parent.X, parent.Y - 1);
                node.Parent = parent;
                nodes.Add(node);
            }

            //below
            if (map.IsValidCoord(parent.X, parent.Y + 1))
            {
                var node = new AStarNode(parent.X, parent.Y + 1);
                node.Parent = parent;
                nodes.Add(node);
            }

            //left
            if (map.IsValidCoord(parent.X - 1, parent.Y))
            {
                var node = new AStarNode(parent.X - 1, parent.Y);
                node.Parent = parent;
                nodes.Add(node);
            }

            //right
            if (map.IsValidCoord(parent.X + 1, parent.Y))
            {
                var node = new AStarNode(parent.X + 1, parent.Y);
                node.Parent = parent;
                nodes.Add(node);
            }

            return nodes;
        }

    }
}
