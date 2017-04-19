using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld
{
    public class DirectedGraph : GraphBase<int>
    {
        public DirectedGraph(int verticesCount)
            : base(verticesCount)
        {
        }

        public override void AddEdges(int edge)
        {
            throw new NotImplementedException();
        }

        public override void AddEdges(int source, int destination)
        {
            this.AdjacencyList[source].Add(destination);
        }

        public override GraphBase<int> EdgeReversalGraph()
        {
            DirectedGraph edgeReversalGraph = new DirectedGraph(this.VerticesCount);

            for (int vertext = 0; vertext < this.AdjacencyList.Count; vertext++)
            {
                for (int edgeVertex = 0; edgeVertex < this.AdjacencyList[vertext].Count; edgeVertex++)
                {
                    edgeReversalGraph.AdjacencyList[edgeVertex].Add(vertext);
                }
            }

            return edgeReversalGraph;
        }
    }
}
