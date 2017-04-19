using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld
{
    public class GraphOrdering<TEdges>
    {
        private GraphBase<TEdges> graph;
        private IGraphSearch graphSearch;

        public Queue<long> PreOrder
        {
            get;
            private set;
        }

        public Queue<long> PostOrder
        {
            get;
            private set;
        }

        public List<long> ReversePostOrder
        {
            get;
            private set;
        }


        public GraphOrdering(GraphBase<TEdges> graph, IGraphSearch graphSearch)
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

            this.graphSearch.VisitingNode += OnVisitingNode;
            this.graphSearch.NodeVisited += OnNodeVisited;
        }

        private void OnVisitingNode(object sender, GraphSearchNodeIndexEventArgs e)
        {
            if (e != null)
            {
                this.PreOrder.Enqueue(e.CurrentNodeIndex);
            }
        }

        private void OnNodeVisited(object sender, GraphSearchNodeIndexEventArgs e)
        {
            if (e != null)
            {
                this.PostOrder.Enqueue(e.CurrentNodeIndex);
                this.ReversePostOrder.Add(e.CurrentNodeIndex);
            }
        }

        public void OrderGraph()
        {
            for (int i = 0; i < this.graph.AdjacencyList.Count; i++)
            {
                if (!this.graphSearch.Visited[i])
                {
                    this.graphSearch.ExploreDirectedGraph(i);
                }
            }
        }
    }
}
