using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GenericHeap
{
    public interface IHeapify<T> where T : IComparable<T>
    {
        void Heapify(IList<T> heapCollection, int index, int heapSize);
    }
}
