using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public abstract class GraphBase<TEdge>
    {
        public List<List<TEdge>> Adj { get; protected set; }

        public long EdgesCount
        {
            get;
            protected set;
        }

        public long VerticiesCount
        {
            get
            {
                return this.Adj.Count;
            }
        }

        public GraphBase()
        {
            this.Adj = new List<List<TEdge>>();
        }

        public GraphBase(int verticiesCount)
        {
            if (verticiesCount < 0)
            {
                throw new ArgumentOutOfRangeException("verticiesCount");
            }

            this.Adj = new List<List<TEdge>>(verticiesCount);
            this.Init(verticiesCount);
        }

        public virtual void AddEdge(int source, TEdge destination)
        {
            if (this.Adj[source] == null)
            {
                this.Adj[source] = new List<TEdge>();
            }

            this.Adj[source].Add(destination);
            this.EdgesCount++;
        }

        public abstract GraphBase<TEdge> Reverse();

        public abstract long AverageDegree();

        public abstract int Degree(int v);

        public int MaxDegree()
        {
            int maxDegree = 0;

            for (int i = 0; i < this.Adj.Count; i++)
            {
                maxDegree = Math.Max(maxDegree, this.Adj[i].Count);
            }

            return maxDegree;
        }

        private void Init(int verticesCount)
        {
            for (int i = 0; i < verticesCount; i++)
            {
                this.Adj.Add(new List<TEdge>());
            }
        }
    }
}
