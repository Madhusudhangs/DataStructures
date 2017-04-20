namespace DataStructures.GenericHeap
{
    using System;
    using System.Collections.Generic;
    using DataStructures.Extension;

    public class MinHeapify<T> : IHeapify<T> where T : IComparable<T>
    {
        public MinHeapify()
        {
        }

        public void Heapify(IList<T> heapCollection, int index)
        {
            this.Heapify(heapCollection, index, heapCollection.Count);
        }

        public void Heapify(IList<T> heapCollection, int index, int heapSize)
        {
            int leftChild = (index << 1) + 1;
            int rightChild = leftChild + 1;

            int minIndex = index;

            if (leftChild >= 0
                && leftChild < heapSize
                && heapCollection[index].CompareTo(heapCollection[leftChild]) > 0)
            {
                minIndex = leftChild;
            }
            else if (rightChild >= 0
                       && rightChild < heapSize
                       && heapCollection[index].CompareTo(heapCollection[rightChild]) > 0)
            {
                minIndex = rightChild;
            }

            if (minIndex != index)
            {
                heapCollection.Swap<T>(index, minIndex);

                this.Heapify(heapCollection, minIndex, heapSize);
            }
        }
    }
}
