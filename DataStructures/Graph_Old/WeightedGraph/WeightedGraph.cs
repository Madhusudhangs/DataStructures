using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.WeightedGraph
{
    public class WeightedGraph : GraphBase<Edge>
    {
        public WeightedGraph(int verticesCount) : base(verticesCount)
        {
        }

        public override void AddEdges(int source, int destination)
        {
            throw new NotImplementedException();
        }

        public override void AddEdges(Edge edge)
        {
            this.AdjacencyList[edge.From].Add(edge);            

        }

        public void AddDirectedEdges(Edge edge)
        {
            if(edge == null)
            {
                throw new ArgumentNullException("edge");
            }

            this.AdjacencyList[edge.From].Add(edge);
        }

        public void AddUnDirectedEdges(Edge edge)
        {
            if (edge == null)
            {
                throw new ArgumentNullException("edge");
            }


            this.AdjacencyList[edge.From].Add(edge);
            this.AdjacencyList[edge.To].Add(edge);
        }

        public override GraphBase<Edge> EdgeReversalGraph()
        {
            throw new NotImplementedException();
        }
    }
}
