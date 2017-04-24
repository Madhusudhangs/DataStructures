namespace DataStructures.Generic
{
    using System;
    using System.Collections.Generic;
    using DataStructures.Extension;
    using DataStructures.Generic.Heap.Extension;

    public class MaxHeapify<T> : IHeapify<T> where T : IComparable<T>
    {
        public void Heapify(IList<T> heapCollection, int index)
        {
            this.HeapifyTopDown(heapCollection, index, heapCollection.Count);
        }

        public void HeapifyBottomUp(IList<T> heapCollection, int index, int heapSize)
        {
            while (index > 1
                   && heapCollection[index.ParentIndex()].CompareTo(heapCollection[index]) < 0)
            {
                heapCollection.Swap(index, index.ParentIndex());
                index = index.ParentIndex();
            }
        }

        public void HeapifyTopDown(IList<T> heapCollection, int index, int heapSize)
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
    }
}
