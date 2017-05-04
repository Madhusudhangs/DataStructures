namespace DataStructures.Generic
{
    using System;
    using System.Collections.Generic;

    public interface IHeapify<T> where T : IComparable<T>, IEquatable<T>
    {
        void HeapifyTopDown(IList<T> heapCollection, int index, int heapSize);

        void HeapifyBottomUp(IList<T> heapCollection, int index, int heapSize);
    }
}
