using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class BreadthFirstSearchNode
    {
        public int X { get; set; }
        public int Y { get; set; }

        public BreadthFirstSearchNode Parent { get; set; }

        public BreadthFirstSearchNode(int x, int y)
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
            return obj is BreadthFirstSearchNode node &&
                   X == node.X &&
                   Y == node.Y;
        }
    }

    public class BreadthFirstSearchAlgorithm : IAlgorithm
    {
        private BreadthFirstSearchNode P;
        private BreadthFirstSearchNode G;
        private List<BreadthFirstSearchNode> visited;
        private Map map;

        public BreadthFirstSearchAlgorithm(int startX, int startY, int goalX, int goalY, string rawData)
        {
            P = new BreadthFirstSearchNode(startX, startY);
            G = new BreadthFirstSearchNode(goalX, goalY);
            map = new Map(rawData);
        }

        public AlgorithmResult run()
        {

            var result = new AlgorithmResult();

            visited = new List<BreadthFirstSearchNode>();
            var queue = new Queue<BreadthFirstSearchNode>();
            queue.Enqueue(P);

            while (true)
            {
                if (queue.Count == 0)
                {
                    break;
                }

                var B = queue.Dequeue();

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
                    queue.Enqueue(C);
                }

                if (breakWhile)
                {
                    break;
                }
            }

            return result;
        }


        public bool IsNodeUnivisited(BreadthFirstSearchNode node)
        {
            var found = visited.FirstOrDefault(x => x.Equals(node));
            return found == null;
        }

        public bool IsValidAdjacent(int x, int y)
        {
            return map.IsValidCoord(x, y) && IsNodeUnivisited(new BreadthFirstSearchNode(x, y));
        }

        public List<BreadthFirstSearchNode> GetUnivisitedAdjacentNodes(BreadthFirstSearchNode parent)
        {
            var nodes = new List<BreadthFirstSearchNode>();

            //above
            if (IsValidAdjacent(parent.X, parent.Y - 1))
            {
                var node = new BreadthFirstSearchNode(parent.X, parent.Y - 1);
                node.Parent = parent;
                nodes.Add(node);
            }

            //below
            if (IsValidAdjacent(parent.X, parent.Y + 1))
            {
                var node = new BreadthFirstSearchNode(parent.X, parent.Y + 1);
                node.Parent = parent;
                nodes.Add(node);
            }

            //left
            if (IsValidAdjacent(parent.X - 1, parent.Y))
            {
                var node = new BreadthFirstSearchNode(parent.X - 1, parent.Y);
                node.Parent = parent;
                nodes.Add(node);
            }

            //right
            if (IsValidAdjacent(parent.X + 1, parent.Y))
            {
                var node = new BreadthFirstSearchNode(parent.X + 1, parent.Y);
                node.Parent = parent;
                nodes.Add(node);
            }

            return nodes;
        }
    }
}
