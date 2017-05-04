namespace DataStructures.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataStructures.Extension;
    using DataStructures.Generic.Heap.Extension;

    public class Heap<T> : IHeapify<T> where T : IComparable<T>, IEquatable<T>
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

            this.HeapCollection = new List<T>(collection);
            this.Size = this.HeapCollection.Count;

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

            this.HeapifyBottomUp(this.HeapCollection, (int)this.Size - 1, (int)this.Size);
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
            return this.HeapCollection.IndexOf(item);
        }

        public virtual void HeapifyBottomUp(IList<T> heapCollection, int index, int heapSize)
        {
            while (index > 1
                   && heapCollection[index.ParentIndex()].CompareTo(heapCollection[index]) < 0)
            {
                heapCollection.Swap(index, index.ParentIndex());
                index = index.ParentIndex();
            }
        }

        public virtual void HeapifyTopDown(IList<T> heapCollection, int index, int heapSize)
        {
            int leftChild = index.LeftChildIndex();
            int rightChild = leftChild.RightChildIndex();

            int maxIndex = index;

            if (leftChild >= 0
                && leftChild < heapSize
                && heapCollection[index].CompareTo(heapCollection[leftChild]) < 0)
            {
                maxIndex = leftChild;
            }
            else if (rightChild >= 0
                       && rightChild < heapSize
                       && heapCollection[index].CompareTo(heapCollection[rightChild]) < 0)
            {
                maxIndex = rightChild;
            }

            if (maxIndex != index)
            {
                heapCollection.Swap<T>(index, maxIndex);

                this.HeapifyTopDown(heapCollection, maxIndex, heapSize);
            }
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
            this.HeapifyTopDown(this.HeapCollection, index, (int)this.Size);
        }
    }
}
