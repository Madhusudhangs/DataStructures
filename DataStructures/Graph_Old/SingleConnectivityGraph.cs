using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld
{
    public class SingleConnectivityGraph
    {
        private List<bool> visited;
        private int[] path;
        private int[] cost;

        private UndirectedGraph graph;

        public SingleConnectivityGraph(UndirectedGraph graph)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph", "Graph instance can't be null or empty");
            }

            this.graph = graph;
            this.visited = new List<bool>();

            this.cost = new int[graph.VerticesCount];
            this.path = new int[graph.VerticesCount];

            for (int i = 0; i < graph.VerticesCount; i++)
            {
                this.visited[i] = false;
            }
        }

        public void DepthFirstSearch(int source)
        {
            if (source < 0 || source >= this.graph.VerticesCount)
            {
                throw new ArgumentOutOfRangeException("source", "Source vertex out of range");
            }

            this.visited[source] = true;
            List<int> neighbors = this.graph.GetNeighbours(source);

            if (neighbors != null
                && neighbors.Any())
            {
                foreach (var neighbor in neighbors)
                {
                    if (!this.visited[neighbor])
                    {
                        this.DepthFirstSearch(neighbor);
                    }
                }
            }
        }

        public bool IsConnected(int source, int destination)
        {
            this.DepthFirstSearchPath(source, destination);
            return this.visited[destination];
        }

        /// <summary>
        ///  Takes O(n) for searching a graph 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public void DepthFirstSearchPath(int source, int destination)
        {
            if (source < 0 || source >= this.graph.VerticesCount)
            {
                throw new ArgumentOutOfRangeException("source", "Source vertex out of range");
            }

            if (source == destination)
            {
                this.visited[destination] = true; // This will make sure that we don't find destination by more than one path.
                return;
            }

            this.visited[source] = true;
            List<int> neighbors = this.graph.GetNeighbours(source);

            if (neighbors != null
                && neighbors.Any())
            {
                // Visit all neighbors and if the destination is not already reached.
                for (int neighbor = 0; neighbor < neighbors.Count && !this.visited[destination]; neighbor++)
                {
                    if (!this.visited[neighbor])
                    {
                        this.path[neighbor] = source; // I came here from its parent.
                        this.cost[neighbor] = this.cost[source] + 1; // Path count to parent + 1
                        this.DepthFirstSearchPath(neighbor, destination);
                    }
                }
            }
        }



        public void DepthFirstSearchShortestPath(int source, int destination)
        {
            if (source < 0 || source >= this.graph.VerticesCount)
            {
                throw new ArgumentOutOfRangeException("source", "Source vertex out of range");
            }

            // As soon as we discover the destination just return from current recursive call without marking
            // destination visited, so that we let the option open to find out the other possible path for the destination.
            if (source == destination)
            {
                return;
            }

            this.visited[source] = true;

            List<int> neighbors = this.graph.GetNeighbours(source);

            if (neighbors != null
                && neighbors.Any())
            {
                for (int neighbor = 0; neighbor < neighbors.Count; neighbor++)
                {
                    if (!this.visited[neighbor])
                    {                      
                        int currentPathCost = this.cost[source] + 1;

                        if (this.cost[neighbor] > 0
                            && this.cost[neighbor] > currentPathCost)
                        {
                            this.path[neighbor] = source; // I came here from its parent.
                            this.cost[neighbor] = this.cost[source] + 1; // Path count to parent + 1
                        }
                                                
                        this.DepthFirstSearchPath(neighbor, destination);
                    }
                }
            }
        }

        //public List<int> GetShortestPath(int source, int destination)
        //{
        //    this.DepthFirstSearchShortestPath(source, destination);

        //    return this. 
        //}

        public List<int> GetPath(int source, int destination)
        {
            Stack<int> path = new Stack<int>();
            //this.pathDiscovered = false;

            if (this.IsConnected(source, destination))
            {
                int dest = destination;
                path.Push(dest);

                while (dest != source)
                {
                    path.Push(this.path[dest]);
                    dest = this.path[dest];
                }
            }

            return path.ToList();
        }

        public int GetDistanceOrCost(int source, int destination)
        {
            if (this.IsConnected(source, destination))
            {
                return this.cost[destination];
            }

            return 0;
        }
    }
}
