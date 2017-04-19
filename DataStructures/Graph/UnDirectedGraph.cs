using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class UnDirectedGraph<TEdge> : GraphBase<TEdge>
    {
        public UnDirectedGraph(int verticiesCount) :
            base(verticiesCount)
        {
        }

        public override void AddEdge(int source, TEdge destination)
        {
            base.AddEdge(source, destination);
           //base.AddEdge(destination., source);

            this.EdgesCount++;
        }

        public override long AverageDegree()
        {
            return 2 * this.EdgesCount / this.VerticiesCount;
        }

        public override int Degree(int v)
        {
            if (this.Adj[v].Any())
            {
                return this.Adj[v].Count;
            }

            return 0;
        }

        public override GraphBase<TEdge> Reverse()
        {
            throw new NotImplementedException();
        }
    }
}
