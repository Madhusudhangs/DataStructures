using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public abstract class HeapElementBase
    {
        internal int KeyIndex
        {
            get;
            set;
        }
    }

    public struct HeapElement<TKey>
    {
        public TKey Key
        {
            get;
            private set;
        }

        public HeapElement(TKey key)
        {
            this.Key = key;
        }

        public int CompareTo(TKey other)
        {
            throw new NotImplementedException();
        }
    }

    public class MinHeap<TKey> where TKey : struct
    {
        private class HeapElement : IComparable<TKey>
        {
            public TKey Key;
            internal int KeyIndex;

            public int CompareTo(TKey other)
            {
                throw new NotImplementedException();
            }
        }

        private List<HeapElement> heap;

        public MinHeap()
        {
            this.heap = new List<HeapElement>();
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public KeyValuePair<TKey, int> this[int index]
        {
            get
            {
                HeapElement item = this.heap[index];
                return new KeyValuePair<TKey, int>(item.Key, item.KeyIndex);
            }
            set
            {
                this.heap[index].Key = value.Key;
                //this.heap[index].KeyIndex = value.Value;
            }
        }

        public void Insert(TKey key, int keyIndex)
        {
            HeapElement heapItem = new HeapElement
            {
                Key = key,
                KeyIndex = keyIndex
            };

            this.heap.Add(heapItem);
        }

        public KeyValuePair<TKey, int> RemoveAt(int index)
        {
            if (index >= this.heap.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            KeyValuePair<TKey, int> item = new KeyValuePair<TKey, int>(this.heap[index].Key, this.heap[index].KeyIndex);
            this.heap.RemoveAt(index);

            return item;
        }


        public void UpdateKey(int index, TKey key)
        {
            this.heap[index].Key = key;
        }


        public void Swap(int index1, int index2)
        {
            HeapElement temp = this.heap[index1];
            this.heap[index1] = this.heap[index2];
            this.heap[index2] = temp;
        }

        public bool Any()
        {
            return this.heap.Any();
        }
    }
}
