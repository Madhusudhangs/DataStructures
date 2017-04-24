using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Generic.Heap.Extension
{
    internal static class HeapExtension
    {
        public static int LeftChildIndex(this int parentIndex)
        {
            return (parentIndex << 1) + 1;
        }

        public static int RightChildIndex(this int parentIndex)
        {
            return parentIndex.LeftChildIndex() + 1;
        }

        public static int ParentIndex(this int childIndex)
        {
            return (childIndex - 1) >> 1;
        }
    }
}
