using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld
{
    public class BreadthFirstSearch : IGraphSearch
    {
        private GraphBase<int> graph;

        private int[] path;
        private int[] weight;

        public List<bool> Visited
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler<GraphSearchNodeIndexEventArgs> NodeVisited;
        public event EventHandler<GraphSearchNodeIndexEventArgs> VisitingNode;

        public BreadthFirstSearch(GraphBase<int> graph)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }

            this.graph = graph;
        }

        public void Explore(int source, int destination)
        {
            Queue<int> longWaitingVertices = new Queue<int>();

            longWaitingVertices.Enqueue(source);

            while (longWaitingVertices.Any())
            {
                int visitedVertex = longWaitingVertices.Dequeue();

                this.Visited[visitedVertex] = true;

                List<int> adjacencyList = this.graph.GetNeighbours(visitedVertex);

                if (adjacencyList != null
                    && adjacencyList.Any())
                {
                    for (int i = 0; i < adjacencyList.Count && !this.Visited[i]; i++)
                    {
                        this.path[i] = visitedVertex;
                        this.weight[i] = this.weight[visitedVertex] + 1;
                        longWaitingVertices.Enqueue(adjacencyList[i]);
                    }
                }
            }
        }

        public void ExploreDirectedGraph(int source)
        {

        }
    }
}
