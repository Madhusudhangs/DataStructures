using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld
{
    public class UndirectedGraph : GraphBase<int>
    {
        public UndirectedGraph(int verticesCount)
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
            this.AdjacencyList[destination].Add(source);
        }

        public override GraphBase<int> EdgeReversalGraph()
        {
            throw new NotImplementedException();
        }
    }
}
