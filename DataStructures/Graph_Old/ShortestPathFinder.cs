using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld
{
    public class ShortestPathFinder
    {
        private IGraphSearch graphSearch;
        private GraphBase<int> graph;

        public ShortestPathFinder(GraphBase<int> graph, IGraphSearch graphSearch)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }

            if (graphSearch == null)
            {
                throw new ArgumentNullException("graphSearch");
            }

            this.graphSearch = graphSearch;
            this.graph = graph;
        }
    }
}
