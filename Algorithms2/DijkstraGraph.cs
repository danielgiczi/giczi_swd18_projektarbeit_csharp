using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class DijkstraGraph
    {
        private Map map;
        public Dictionary<string, DijkstraNode> Nodes { get; protected set; }

        public DijkstraGraph(Map map)
        {
            this.map = map;

            Nodes = new Dictionary<string, DijkstraNode>();

            for (var x = 0; x < this.map.GetWidth(); x++)
            {
                for (var y = 0; y < this.map.GetHeight(); y++)
                {
                    var node = new DijkstraNode(x, y);
                    node.Weight = this.map.GetCoordCost(x, y);
                    if (node.Weight == 8) node.Weight = int.MaxValue;
                    Nodes.Add(node.ToString(), node);
                }
            }

            foreach (var key in Nodes.Keys)
            {
                var node = Nodes[key];
                if(!node.Selected)
                {
                    calcAdjacentNodes(node);
                }
            }
        }

        private void calcAdjacentNodes(DijkstraNode parent)
        {
            parent.Adjacents = new List<DijkstraNode>();

            var above = Get(parent.X, parent.Y - 1);
            if(above != null)
            {
                parent.Adjacents.Add(above);
            }

            var below = Get(parent.X, parent.Y + 1);
            if(below != null)
            {
                parent.Adjacents.Add(below);
            }

            var left = Get(parent.X - 1, parent.Y);
            if (left != null)
            {
                parent.Adjacents.Add(left);
            }

            var right = Get(parent.X + 1, parent.Y);
            if (right != null)
            {
                parent.Adjacents.Add(right);
            }
        }

        public DijkstraNode Get(int x, int y)
        {
            if(!map.IsWithinBounds(x,y))
            {
                return null;
            }
            else
            {
                return Nodes[x + "|" + y];
            }
        }

        public List<DijkstraNode> GetSortedUnexploredList()
        {
            var list = new List<DijkstraNode>();

            foreach (var key in Nodes.Keys)
            {
                var node = Nodes[key];
                if (!node.Selected)
                {
                    list.Add(node);
                }
            }

            list = list.OrderBy(x => x.Distance).ToList();

            return list;
        }


        public void reset()
        {
            foreach (var key in Nodes.Keys)
            {
                var node = Nodes[key];
                node.Distance = int.MaxValue;
                node.Selected = false;
            }
        }
    }
}
