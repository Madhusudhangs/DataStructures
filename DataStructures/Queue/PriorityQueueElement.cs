using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public abstract class PriorityQueueItemBase
    {
        public int HeapIndex
        {
            get;
            set;
        }
    }

    public class PriorityQueueElement<TData>:PriorityQueueItemBase
    {
        public TData Data
        {
            get;
            private set;
        }

        public PriorityQueueElement(TData data)
        {
            this.Data = data;
        }

        public void UpdateHeapIndex(int heapIndex)
        {
            this.HeapIndex = heapIndex;
        }
    }
}
