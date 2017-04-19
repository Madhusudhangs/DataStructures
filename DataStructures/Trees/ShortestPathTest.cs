using DataStructures.Graph;
using DataStructures.ShortestPathAlgo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class ShortestPathTest
    {
        public static void TestShortestPathWithNoNegativeCycle()
        {
            DirectedGraph<DirectedWeightedEdge<int>> graph = new DirectedGraph<DirectedWeightedEdge<int>>(5);

            Dictionary<int, string> vertex = new Dictionary<int,string>();
            vertex.Add(0, "s");
            vertex.Add(1, "t");
            vertex.Add(2, "x");
            vertex.Add(3, "y");
            vertex.Add(4, "z");


            graph.AddEdge(0, new DirectedWeightedEdge<int>(0, 1, 6));
            graph.AddEdge(0, new DirectedWeightedEdge<int>(0, 3, 7));

            graph.AddEdge(1, new DirectedWeightedEdge<int>(1, 2, 5));
            graph.AddEdge(1, new DirectedWeightedEdge<int>(1, 3, 8));
            graph.AddEdge(1, new DirectedWeightedEdge<int>(1, 4, -4));

            //graph.AddEdge(2, new DirectedWeightedEdge<int>(2, 1, -2));

            //graph.AddEdge(3, new DirectedWeightedEdge<int>(3, 2, -3));
            graph.AddEdge(3, new DirectedWeightedEdge<int>(3, 4, 9));

            graph.AddEdge(4, new DirectedWeightedEdge<int>(4, 2, 7));
            graph.AddEdge(4, new DirectedWeightedEdge<int>(4, 0, 2));

            BellmanFordST shortestPath = new BellmanFordST(graph);
            if (shortestPath.ShortestPath(5))
            {
                // Shortest path
                foreach (var item in shortestPath.GetShortestPath(4))
                {
                    Console.WriteLine(vertex[item]);
                }

                double distance = shortestPath.GetShortestDistance(4);

                Console.WriteLine("Shortest Distance:{0}", distance);
            }
            else
            {
                Console.WriteLine("Negative Cycle found!");
            }
        }
    }
}
