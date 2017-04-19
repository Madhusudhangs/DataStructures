using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class DirectedWeightedEdge<TVertex>
    {
        public TVertex From { get; private set; }

        public TVertex To { get; private set; }

        public double Weight { get; private set; }

        public DirectedWeightedEdge(TVertex from, TVertex to, double weight)
        {
            this.From = from;
            this.To = to;
            this.Weight = weight;
        }
    }
}
