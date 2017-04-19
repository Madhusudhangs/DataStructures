using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class DirectedGraph<TEdge> : GraphBase<TEdge>
    {
        public DirectedGraph(int verticiesCount) :
            base(verticiesCount)
        {
        }

        public override long AverageDegree()
        {
            return this.EdgesCount / this.VerticiesCount;
        }

        public override int Degree(int v)
        {
            throw new NotImplementedException();
        }

        public override GraphBase<TEdge> Reverse()
        {
            throw new NotImplementedException();
        }
    }
}
