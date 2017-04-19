using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld
{
    public class GraphSearchNodeIndexEventArgs : EventArgs
    {
        public long CurrentNodeIndex
        {
            get;
            private set;
        }

        public GraphSearchNodeIndexEventArgs(long nodeIndex)
        {
            this.CurrentNodeIndex = nodeIndex;
        }
    }
}
