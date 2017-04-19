using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class SymbolGraph<T> where T : IComparable<T>
    {
        private Dictionary<T, int> symbolTable;
        private List<T> keys;

        //private Graph graph;

        public SymbolGraph(IList<T> items, bool isDirectedGraph)
        {
            this.symbolTable = new Dictionary<T, int>();
            this.keys = new List<T>();




            //if (isDirectedGraph)
            //{
            //    this.graph = new DirectedGraph(items.Count);
            //}
            //else
            //{
            //    this.graph = new UnDirectedGraph(items.Count);
            //}
        }
    }
}
