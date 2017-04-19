using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld
{
    public interface IGraphSearch
    {
        List<bool> Visited { get; set; }

        event EventHandler<GraphSearchNodeIndexEventArgs> VisitingNode;

        event EventHandler<GraphSearchNodeIndexEventArgs> NodeVisited;

        void ExploreDirectedGraph(int source);

        void Explore(int source, int destination);

    }
}
