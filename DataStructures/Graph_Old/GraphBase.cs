using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld
{
    public abstract class GraphBase<TEdges>
    {
        public List<List<TEdges>> AdjacencyList
        {
            get;
            protected set;
        }

        public int VerticesCount
        {
            get
            {
                return this.AdjacencyList.Count;
            }
        }

        public GraphBase(int verticesCount)
        {
            this.AdjacencyList = new List<List<TEdges>>(verticesCount);

            for (int i = 0; i < verticesCount; i++)
            {
                this.AdjacencyList[i] = new List<TEdges>();
            }
        }

        public List<TEdges> GetNeighbours(int source)
        {
            if (source < 0 || source >= this.VerticesCount)
            {
                throw new ArgumentOutOfRangeException("source", "Source vertex out of range");
            }

            return this.AdjacencyList[source];
        }

        public abstract void AddEdges(int source, int destination);

        public abstract void AddEdges(TEdges edge);

        public abstract GraphBase<TEdges> EdgeReversalGraph();
    }
}
