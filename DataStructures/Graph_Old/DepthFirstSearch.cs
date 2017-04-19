using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld
{
    public class DepthFirstSearch : IGraphSearch
    {
        private GraphBase<int> graph;

        public List<bool> Visited
        {
            get;
            set;
        }

        public object EventArgs { get; private set; }

        public event EventHandler<GraphSearchNodeIndexEventArgs> VisitingNode;

        public event EventHandler<GraphSearchNodeIndexEventArgs> NodeVisited;

        public event EventHandler EncounteredCycle;

        private bool stopSearchWhenCycleEncountered;

        public DepthFirstSearch(GraphBase<int> graph)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph", "Graph instance can't be null");
            }

            this.graph = graph;
            this.Visited = new List<bool>();

            for (int i = 0; i < graph.VerticesCount; i++)
            {
                this.Visited[i] = false;
            }
        }

        public void ExploreDirectedGraph(int source)
        {
            this.Visited[source] = true;

            if (this.VisitingNode != null)
            {
                this.VisitingNode(this, new GraphSearchNodeIndexEventArgs(source));
            }

            List<int> neighbors = this.graph.GetNeighbours(source);

            if (neighbors != null
                && neighbors.Any())
            {
                foreach (var neighbor in neighbors)
                {
                    if (!this.Visited[neighbor])
                    {
                        this.ExploreDirectedGraph(neighbor);
                    }
                    else if (this.EncounteredCycle != null)
                    {
                        this.EncounteredCycle(this, System.EventArgs.Empty);
                    }
                }
            }

            if (this.NodeVisited != null)
            {
                this.NodeVisited(this, new GraphSearchNodeIndexEventArgs(source));
            }
        }

        public void Explore(int source, int destination)
        {
            if (source == destination)
            {
                return;
            }

            this.Visited[source] = true;

            List<int> neighbors = this.graph.GetNeighbours(source);

            if (neighbors != null
                && neighbors.Any())
            {
                foreach (var neighbor in neighbors)
                {
                    if (!this.Visited[neighbor])
                    {
                        this.ExploreDirectedGraph(neighbor);
                    }
                }
            }
        }
    }
}
