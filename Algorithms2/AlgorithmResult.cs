using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms
{
    public class AlgorithmResult
    {
        public List<Probes> Probes { get; set; } = new List<Probes>();
        public List<Paths> Paths { get; set; } = new List<Paths>();
        public long Ms { get; set; }
        public bool Found
        {
            get
            {
                return Paths.Count > 0;
            }
        }

        public AlgorithmResult() { }

        public AlgorithmResult(List<Probes> probes, List<Paths> paths)
        {
            Probes = probes;
            Paths = paths;
        }
    }
}
