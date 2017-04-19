using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GenericHeap
{
    public class Heap<T> where T : IComparable<T>
    {
        private List<T> heapList;
        private long size;

        private IHeapify<T> heapify;

        public Heap()
            : this(Enumerable.Empty<T>())
        {
        }

        public Heap(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            this.heapList = new List<T>(collection);
            this.size = this.heapList.Count;
        }

        public void Insert(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            this.size++;
            this.heapList.Add(item);

            this.Heapify((int)this.size);
        }

        public T ExtractTop()
        {

        }

        public T RemoveAt(int index)
        {

        }

        private void Heapify(int index)
        {
            if (heapify != null)
            {
                this.heapify.Heapify(this.heapList, index, (int)this.size);
            }
        }

        private void BuildHeap()
        {
            int mid = (int)(this.size / 2);

            for (int i = mid; i >= 0; i--)
            {
                this.Heapify(i);
            }
        }
    }
}
