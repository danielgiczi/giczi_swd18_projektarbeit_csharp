using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Map
    {
        private List<List<int>> rawInput;
        public int StartX { get; protected set; }
        public int StartY { get; protected set; }
        public int DestX { get; protected set; }
        public int DestY { get; protected set; }

        public Map(string chosenMap)
        {
            chosenMap = Regex.Replace(chosenMap, "\r", "");
            var rows = chosenMap.Split("\n");

            var mapArr = new List<List<int>>();

            int startX = -1;
            int startY = -1;
            int destX = -1;
            int destY = -1;

            var rowInx = 0;
            foreach (var val in rows)
            {
                if (String.IsNullOrWhiteSpace(val)) continue;
                var row = Regex.Replace(val, @"\s\s +", " ");
                if (String.IsNullOrWhiteSpace(row)) continue;
                var chars = row.Split(" ");

                var rowArr = new List<int>();
                var colInx = 0;

                foreach (var chr in chars)
                {
                    if (String.IsNullOrWhiteSpace(chr)) continue;
                    var weight = 0;
                    if (chr == "S")
                    {
                        weight = 0;
                        startX = colInx;
                        startY = rowInx;
                    }
                    else if (chr == "D")
                    {
                        weight = 0;
                        destX = colInx;
                        destY = rowInx;
                    }
                    else
                    {
                        weight = int.Parse(chr);
                    }

                    rowArr.Add(weight);
                    colInx++;
                }


                if (rowArr.Count == 0) return;
                mapArr.Add(rowArr);
                rowInx++;
            }

            rawInput = mapArr;

            if (startX == -1 || startY == -1)
            {
                throw new ArgumentException("invalid start " + startX + " " + startY);
            }

            StartX = startX;
            StartY = startY;

            if (destX == -1 || destY == -1)
            {
                throw new ArgumentException("invalid dest " + destX + " " + destY);
            }

            DestX = destX;
            DestY = destY;
        }

        public int GetCoordCost(int x, int y)
        {
            return Math.Abs(rawInput[y][x]);
        }

        public int GetHeight()
        {
            return rawInput.Count;
        }

        public int GetWidth()
        {
            return rawInput[0].Count;
        }

        public IEnumerable<List<int>> ForEach()
        {
            return rawInput.AsEnumerable();
        }

        public bool IsWithinBounds(int x, int y)
        {
            if (x < 0) return false;
            if (x >= this.GetWidth()) return false;
            if (y < 0) return false;
            if (y >= this.GetHeight()) return false;
            return true;
        }

        public bool IsValidCoord(int x, int y)
        {
            if (!IsWithinBounds(x, y)) return false;
            var cost = GetCoordCost(x, y);
            if (cost == 8) return false;
            return true;
        }
    }
}
