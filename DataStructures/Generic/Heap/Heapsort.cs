namespace DataStructures.GenericHeap
{
    using System;
    using System.Collections.Generic;
    using DataStructures.Extension;
    using Generic;

    public class Heapsort<T> : Heap<T> where T : IComparable<T>, IEquatable<T>
    {
        public Heapsort(IList<T> collection)
            : base(collection)
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
