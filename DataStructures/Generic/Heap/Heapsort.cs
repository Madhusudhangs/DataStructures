namespace DataStructures.Generic
{
    using System;
    using System.Collections.Generic;
    using DataStructures.Extension;

    public class Heapsort<T> : Heap<T> where T : IComparable<T>
    {
        public Heapsort(IList<T> collection)
            : this(collection, new MaxHeapify<T>())
        {
        }

        public Heapsort(IList<T> collection, IHeapify<T> heapify)
            : base(collection, heapify)
        {
        }

        public IList<T> Sort()
        {
            for (int i = (int)this.Size - 1; i > 0; i--)
            {
                this.HeapCollection.Swap(i, 0);
                this.Size--;

                this.Heapify(0);
            }

            return this.HeapCollection;
        }
    }
}
