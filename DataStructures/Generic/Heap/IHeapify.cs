namespace DataStructures.Generic
{
    using System;
    using System.Collections.Generic;

    public interface IHeapify<T> where T : IComparable<T>
    {
        void Heapify(IList<T> heapCollection, int index, int heapSize);
    }
}
