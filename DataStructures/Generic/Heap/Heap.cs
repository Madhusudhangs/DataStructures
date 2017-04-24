namespace DataStructures.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataStructures.Extension;

    public class Heap<T> where T : IComparable<T>, IEquatable<T>
    {
        public List<T> HeapCollection
        {
            get;
            protected set;
        }

        public long Size
        {
            get;
            protected set;
        }

        private IHeapify<T> heapify;

        public Heap()
            : this(Enumerable.Empty<T>(), new MaxHeapify<T>())
        {
        }

        public Heap(IEnumerable<T> collection, IHeapify<T> heapify)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            if (heapify == null)
            {
                throw new ArgumentNullException("heapify");
            }


            this.HeapCollection = new List<T>(collection);
            this.Size = this.HeapCollection.Count;
            this.heapify = heapify;

            if (this.HeapCollection.Any())
            {
                this.BuildHeap();
            }
        }

        public void Insert(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            this.Size++;
            this.HeapCollection.Add(item);

            this.heapify.HeapifyBottomUp(this.HeapCollection, (int)this.Size - 1, (int)this.Size);
        }

        public T Top()
        {
            return this.HeapCollection[0];
        }

        public T ExtractTop()
        {
            T top = this.HeapCollection[0];

            int lastElementIndex = (int)(Size - 1);
            this.HeapCollection.Swap(0, lastElementIndex);
            this.HeapCollection.RemoveAt(lastElementIndex);
            this.Size--;

            this.Heapify(0);

            return top;
        }

        public int FindIndex(T item)
        {
            return this.HeapCollection.FindIndex(0, (element) => element.Equals(item));
        }

        protected void BuildHeap()
        {
            int mid = (int)(this.Size / 2);

            for (int i = mid; i >= 0; i--)
            {
                this.Heapify(i);
            }
        }

        protected void Heapify(int index)
        {
            if (heapify != null)
            {
                this.heapify.HeapifyTopDown(this.HeapCollection, index, (int)this.Size);
            }
        }
    }
}
