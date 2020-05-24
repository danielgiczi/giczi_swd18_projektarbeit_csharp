using System;

namespace Algorithms
{
    public class InvokerData
    {
        public int AlgorithmIndex { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int DestX { get; set; }
        public int DestY { get; set; }
        public string MapData { get; set; }
    }

    public class AlgorithmInvoker
    {
        public static AlgorithmResult Invoke(InvokerData data)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            IAlgorithm algorithm;
            switch (data.AlgorithmIndex)
            {
                case 0:
                    algorithm = new AStarAlgorithm(data.StartX, data.StartY, data.DestX, data.DestY, data.MapData);
                    break;
                case 1:
                    algorithm = new DijkstraAlgorithm(data.StartX, data.StartY, data.DestX, data.DestY, data.MapData);
                    break;
                case 2:
                    algorithm = new BreadthFirstSearchAlgorithm(data.StartX, data.StartY, data.DestX, data.DestY, data.MapData);
                    break;
                case 3:
                    algorithm = new DepthFirstSearchAlgorithm(data.StartX, data.StartY, data.DestX, data.DestY, data.MapData);
                    break;
                default:
                    throw new ArgumentException();
            }

            var result = algorithm.run();

            sw.Stop();

            result.Ms = sw.ElapsedMilliseconds;

            return result;
        }
    }
}
