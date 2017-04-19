//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataStructures.Graph
//{
//    public class DijkstrasShortestPath
//    {
//        private bool[] visited;
//        private int[] distance;
//        private int[] path;
//        private PriorityQueue<int> priorityQueue;

//        public DijkstrasShortestPath(UndirectedGraph graph, int source)
//        {
//            this.visited = new bool[graph.VerticesCount];
//            this.distance = new int[graph.VerticesCount];

//            for (int i = 0; i < graph.VerticesCount; i++)
//            {
//                this.distance[i] = int.MaxValue;
//            }

//            this.distance[source] = 0;
//            this.path = new int[graph.VerticesCount];
//            priorityQueue = new PriorityQueue<int>();

//            while (priorityQueue != empty)
//            {
//                Relax(graph, priorityQueue.DeleteMin())
//            }
//        }

//        private void Relax(UndirectedGraph graph, int v)
//        {
//            foreach (var directedEdge e in collection)
//            {
//                int w = e.To();

//                if(this.distance[w] > this.distance[v] +e.weight)
//                {
//                    distance[w] = distance[v]+e.weight;
//                    path[w]=e.weight;

//                    if(priorityQueue.Contains(w))
//                    {
//                        priorityQueue.Updata(w, distance[w]);
//                    }
//                    else
//                    {
//                        priorityQueue.Insert(w.distance[w]);
//                    }
//                }
//            }
//        }
//    }
//}
