using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld.WeightedGraph
{
    public class Edge
    {
        public int From { get; private set; }

        public int To { get; private set; }

        public double Weight { get; private set; }

        public Edge(int from, int to, double weight)
        {
            this.From = from;
            this.To = to;
            this.Weight = weight;
        }
    }
}
