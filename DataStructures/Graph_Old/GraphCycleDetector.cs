using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld
{
    public class GraphCycleDetector
    {
        private IGraphSearch graphSearch;
        private GraphBase<int> graph;

        public GraphCycleDetector(GraphBase<int> graph, IGraphSearch graphSearch)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph", "Graph instance can't be null");
            }

            if (graphSearch == null)
            {
                throw new ArgumentNullException("graphSearch", "Graph Search instance can't be null");
            }

            this.graph = graph;
            this.graphSearch = graphSearch;
        }

        public bool HasCycle()
        {
            for (int i = 0; i < this.graph.VerticesCount; i++)
            {
                if (this.graphSearch.Visited[i])
                {
                    if ((this.graph as UndirectedGraph) != null && this.HasCycleInUnDigraph(i, -1))
                    {
                        return true;
                    }
                    else if ((this.graph as DirectedGraph) != null && this.HasCycleInDigraph(i))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool HasCycleInDigraph(int source)
        {
            this.graphSearch.Visited[source] = true;

            var neighbors = this.graph.AdjacencyList[source];

            if (neighbors != null
                && neighbors.Any())
            {
                for (int j = 0; j < neighbors.Count; j++)
                {
                    if (!this.graphSearch.Visited[j] && HasCycleInDigraph(j))
                    {
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool HasCycleInUnDigraph(int source, int parent)
        {
            this.graphSearch.Visited[source] = true;

            var neighbors = this.graph.AdjacencyList[source];

            if (neighbors != null
                && neighbors.Any())
            {
                for (int i = 0; i < neighbors.Count; i++)
                {
                    if (!this.graphSearch.Visited[i] && HasCycleInUnDigraph(i, source))
                    {
                        return true;
                    }
                    else if (i != parent)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
