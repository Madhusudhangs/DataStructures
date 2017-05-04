namespace DataStructures.Generic.Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataStructures.Extension;
    using DataStructures.Generic.Heap.Extension;

    public class IndexPriorityQueue<T> : Heap<int>, IHeapify<T> where T : IComparable<T>, IEquatable<T>
    {
        private List<int> heapIndex;

        public List<T> InputCollection
        {
            get;
            private set;
        }

        public IndexPriorityQueue()
            : base(Enumerable.Empty<int>())
        {
            this.InputCollection = new List<T>();
            this.heapIndex = new List<int>();
        }

        public void Enqueue(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            this.InputCollection.Add(item);

            this.HeapCollection.Add(this.InputCollection.Count - 1);
            this.Size++;
            this.heapIndex.Add((int)this.Size - 1);

            this.HeapifyBottomUp(this.HeapCollection, (int)Size - 1, (int)this.Size);
        }

        public T Dequeue()
        {
            T item = this.InputCollection[this.HeapCollection[0]];
            this.heapIndex[this.HeapCollection[0]] = -1;

            this.HeapCollection.Swap(0, (int)(this.Size - 1));
            this.HeapCollection.RemoveAt((int)(this.Size - 1));
            this.Size--;

            this.HeapifyTopDown(this.HeapCollection, 0, (int)this.Size);

            return item;
        }

        public T Peek()
        {
            return this.InputCollection[this.HeapCollection[0]];
        }

        public void ChangePriority(T oldItem, T newItem)
        {
            if (oldItem.Equals(newItem))
            {
                return;
            }

            int index = this.InputCollection.IndexOf(oldItem);

            if (index < 0)
            {
                throw new InvalidOperationException("item not found");
            }

            this.HeapifyBottomUp(this.HeapCollection, this.heapIndex[index], (int)this.Size);
            this.HeapifyTopDown(this.HeapCollection, this.heapIndex[index], (int)this.Size);
        }

        public void ChangePriority(int index, T newItem)
        {
            if (index < 0
                && index >= this.Size)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }

            if (this.HeapCollection[index].Equals(newItem))
            {
                return;
            }

            this.InputCollection[index] = newItem;

            this.HeapifyBottomUp(this.HeapCollection, this.heapIndex[index], (int)this.Size);
            this.HeapifyTopDown(this.HeapCollection, this.heapIndex[index], (int)this.Size);
        }

        public void HeapifyBottomUp(IList<T> heapCollection, int index, int heapSize)
        {
            int itemIndex = index;
            int parentIndex = index.ParentIndex();

            while (itemIndex > 0
                && this.InputCollection[this.heapIndex[this.HeapCollection[index]]].CompareTo(this.InputCollection[this.heapIndex[this.HeapCollection[parentIndex]]]) > 0)
            {
                this.HeapCollection.Swap(index, parentIndex);

                this.heapIndex.Swap(this.HeapCollection[index], this.HeapCollection[parentIndex]);

                index = parentIndex;
                parentIndex = index.ParentIndex();
            }
        }

        public void HeapifyTopDown(IList<T> heapCollection, int index, int heapSize)
        {
            int left = index.LeftChildIndex();
            int right = index.RightChildIndex();

            int heapifyIndex = index;

            if (left >= 0
                && left < heapSize
                && this.InputCollection[this.heapIndex[this.HeapCollection[index]]].CompareTo(this.InputCollection[this.heapIndex[this.HeapCollection[left]]]) < 0)
            {
                heapifyIndex = left;
            }
            else if (right >= 0
                && right < heapSize
                && this.InputCollection[this.heapIndex[this.HeapCollection[index]]].CompareTo(this.InputCollection[this.heapIndex[this.HeapCollection[right]]]) < 0)
            {
                heapifyIndex = right;
            }

            if (heapifyIndex != index)
            {
                heapCollection.Swap(index, heapifyIndex);
                this.heapIndex.Swap(this.HeapCollection[index], this.HeapCollection[heapifyIndex]);

                this.HeapifyTopDown(heapCollection, heapifyIndex, heapSize);
            }
        }
    }
}
