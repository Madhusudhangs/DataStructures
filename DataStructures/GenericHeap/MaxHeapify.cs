namespace DataStructures.GenericHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeapify<T> : IHeapify<T> where T : IComparable<T>
    {
        public void Heapify(IList<T> heapCollection, int index)
        {
            this.Heapify(heapCollection, index, heapCollection.Count);
        }

        public void Heapify(IList<T> heapCollection, int index, int heapSize)
        {
            int leftChild = (index << 1) + 1;
            int rightChild = leftChild + 1;

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

                this.Heapify(heapCollection, maxIndex, heapSize);
            }
        }
    }
}
