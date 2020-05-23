using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class DepthFirstSearchNode
    {
        public int X { get; set; }
        public int Y { get; set; }

        public DepthFirstSearchNode Parent { get; set; }

        public DepthFirstSearchNode(int x, int y)
        {
            X = x;
            Y = y;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Parent);
        }

        public override bool Equals(object obj)
        {
            return obj is DepthFirstSearchNode node &&
                   X == node.X &&
                   Y == node.Y;
        }
    }

    public class DepthFirstSearchAlgorithm : IAlgorithm
    {
        private DepthFirstSearchNode P;
        private DepthFirstSearchNode G;
        private List<DepthFirstSearchNode> visited;
        private Map map;

        public DepthFirstSearchAlgorithm(int startX, int startY, int goalX, int goalY, string rawData)
        {
            P = new DepthFirstSearchNode(startX, startY);
            G = new DepthFirstSearchNode(goalX, goalY);
            map = new Map(rawData);
        }

        public AlgorithmResult run()
        {
            
            var result = new AlgorithmResult();

            visited = new List<DepthFirstSearchNode>();
            var stack = new Stack<DepthFirstSearchNode>();
            stack.Push(P);

            while (true)
            {
                if (stack.Count == 0)
                {
                    break;
                }

                var B = stack.Pop();

                var adjacentNodes = GetUnivisitedAdjacentNodes(B);
                visited.Add(B);

                bool breakWhile = false;
                for (var adjacentNodeIndex = 0; adjacentNodeIndex < adjacentNodes.Count; adjacentNodeIndex++)
                {
                    var C = adjacentNodes[adjacentNodeIndex];

                    if (C.Equals(this.G))
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

                    result.Probes.Add(new Probes(C.X, C.Y));
                    visited.Add(C);
                    stack.Push(C);
                }

                if (breakWhile)
                {
                    break;
                }
            }

            return result;
        }


        public bool IsNodeUnivisited(DepthFirstSearchNode node)
        {
            var found = visited.FirstOrDefault(x => x.Equals(node));
            return found == null;
        }

        public bool IsValidAdjacent(int x, int y)
        {
            return map.IsValidCoord(x, y) && IsNodeUnivisited(new DepthFirstSearchNode(x, y));
        }

        public List<DepthFirstSearchNode> GetUnivisitedAdjacentNodes(DepthFirstSearchNode parent)
        {
            var nodes = new List<DepthFirstSearchNode>();

            //above
            if (IsValidAdjacent(parent.X, parent.Y - 1))
            {
                var node = new DepthFirstSearchNode(parent.X, parent.Y - 1);
                node.Parent = parent;
                nodes.Add(node);
            }

            //below
            if (IsValidAdjacent(parent.X, parent.Y + 1))
            {
                var node = new DepthFirstSearchNode(parent.X, parent.Y + 1);
                node.Parent = parent;
                nodes.Add(node);
            }

            //left
            if (IsValidAdjacent(parent.X - 1, parent.Y))
            {
                var node = new DepthFirstSearchNode(parent.X - 1, parent.Y);
                node.Parent = parent;
                nodes.Add(node);
            }

            //right
            if (IsValidAdjacent(parent.X + 1, parent.Y))
            {
                var node = new DepthFirstSearchNode(parent.X + 1, parent.Y);
                node.Parent = parent;
                nodes.Add(node);
            }

            return nodes;
        }
    }
}
