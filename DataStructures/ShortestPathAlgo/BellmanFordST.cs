using DataStructures.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.ShortestPathAlgo
{
    public class BellmanFordST
    {
        private GraphBase<DirectedWeightedEdge<int>> graph;
        private double[] weight;
        private int[] path;

        private int source;

        public BellmanFordST(GraphBase<DirectedWeightedEdge<int>> graph)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }

            this.graph = graph;
            this.weight = new double[graph.VerticiesCount];
            this.path = new int[graph.VerticiesCount];
        }

        public bool ShortestPath(int source)
        {
            this.source = source;
            this.Initialize(source);

            for (int i = 1; i < this.graph.VerticiesCount - 1; i++)
            {
                for (int vertexFrom = 0; vertexFrom < this.graph.VerticiesCount; vertexFrom++)
                {
                    for (int vertexTo = 0; vertexTo < this.graph.Adj[vertexFrom].Count; vertexTo++)
                    {
                        this.Relax(this.graph.Adj[vertexFrom][vertexTo]);
                    }
                }
            }

            for (int vertexFrom = 0; vertexFrom < this.graph.VerticiesCount; vertexFrom++)
            {
                for (int vertexTo = 0; vertexTo < this.graph.Adj[vertexFrom].Count; vertexTo++)
                {
                    if (this.weight[this.graph.Adj[vertexFrom][vertexTo].To] > this.weight[vertexFrom] + this.graph.Adj[vertexFrom][vertexTo].Weight)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public List<int> GetShortestPath(int toVertex)
        {
            List<int> shortestPath = new List<int>();

            for (int i = toVertex; i != source; i = this.path[i])
            {
                shortestPath.Add(i);
            }

            shortestPath.Add(source);

            return shortestPath;
        }

        public double GetShortestDistance(int destination)
        {
            return this.weight[destination];
        }


        private void Initialize(int source)
        {
            for (int i = 0; i < this.weight.Length; i++)
            {
                this.weight[i] = double.PositiveInfinity;
                this.path[i] = -1;
            }

            this.weight[source] = 0;
        }

        private void Relax(DirectedWeightedEdge<int> edge)
        {
            if (this.weight[edge.To] > this.weight[edge.From] + edge.Weight)
            {
                this.weight[edge.To] = this.weight[edge.From] + edge.Weight;
                this.path[edge.To] = edge.From;
            }
        }
    }
}
