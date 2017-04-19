using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld
{
    public class TopoligicalOrderingForDirectedGraph
    {
        private GraphBase<int> graph;
        private IGraphSearch graphSearch;       


        public TopoligicalOrderingForDirectedGraph(GraphBase<int> graph, IGraphSearch graphSearch)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph", "Graph instance can't be null");
            }

            if (graphSearch == null)
            {
                throw new ArgumentNullException("graphSearch", "GraphSearch instance can't be null");
            }

            this.graph = graph;
            this.graphSearch = graphSearch;

            for (int i = 0; i < graph.VerticesCount; i++)
            {
                if (!graphSearch.Visited[i])
                {
                    this.graphSearch.ExploreDirectedGraph(i);
                }
            }
        }
    }
}
