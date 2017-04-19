using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public class MinPriorityQueue
    {
        private MinHeap heap;

        public MinPriorityQueue(MinHeap heap)
        {
            if (heap == null)
            {
                throw new ArgumentNullException("heap");
            }

            this.heap = heap;
        }

        public void Insert(int key)
        {
            this.heap.InsertItem(key);
        }

        public void Delete(int index)
        {
            this.heap.DeleteKey(index);
        }

        public void ChangeKey(int index, int key)
        {
            this.heap.IncreaseKey(index, key);
            this.heap.DecreaseKey(index, key);
        }

        public int GetMin()
        {
            return this.heap.HeapMin();
        }

        public int ExtractMin()
        {
            return this.heap.ExtractHeapMin();
        }
    }
}
