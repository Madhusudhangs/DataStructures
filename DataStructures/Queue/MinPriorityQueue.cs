using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public class InfinityBase<T> where T : struct, IConvertible
    {      

        public static T PosInfinity
        {
            get;
        }

        public static T NegInfinity
        {
            get;
        }
    }

    //public class IntInfinity : InfinityBase<int>
    //{
    //    public override int PosInfinity
    //    {
    //        get
    //        {
    //            return int.MaxValue;
    //        }
    //    }

    //    public override int NegInfinity
    //    {
    //        get
    //        {
    //            return int.MinValue;
    //        }
    //    }
    //}

    public class MinPriorityQueue<Item, TPriority> where Item : PriorityQueueItemBase where TPriority : struct, IComparable<TPriority>,IComparable<Item>
    {
        private List<Item> queueItems;
        private MinHeap<TPriority> minHeap;

        public MinPriorityQueue()
        {
            this.queueItems = new List<Item>();
            this.minHeap = new MinHeap<TPriority>();
        }

        public Item Min()
        {
            if (this.minHeap.Any())
            {
                throw new InvalidOperationException("Queue Underflow");
            }

            return this.queueItems[this.minHeap[0].Value];
        }

        public Item ExtractMin()
        {
            if (this.minHeap.Any())
            {
                throw new InvalidOperationException("Queue Underflow");
            }

            int itemIndex = this.minHeap[0].Value;
            Item min = this.queueItems[itemIndex];

            this.minHeap.Swap(0, this.minHeap.Count - 1);
            this.queueItems[this.minHeap[0].Value].HeapIndex = 0;

            this.queueItems[itemIndex] = default(Item);
            this.minHeap.RemoveAt(this.minHeap.Count - 1);

            this.Heapify(0);

            return min;
        }
        
        public bool Contains(int itemIndex)
        {
            return this.queueItems[itemIndex] != null;
        }

        public void DecreasePriority(int index, TPriority priority)
        {
            int heapIndex = this.queueItems[index].HeapIndex;

            if (this.minHeap[heapIndex].Key.CompareTo(priority) >= 0)
            {
                return;
            }

            this.minHeap.UpdateKey(heapIndex, priority);

            while (heapIndex >= 0 && this.minHeap[heapIndex].Key.CompareTo(this.minHeap[this.Parent(heapIndex)].Key) < 0)
            {
                int parentIndex = this.Parent(heapIndex);
                this.queueItems[this.minHeap[heapIndex].Value].HeapIndex = parentIndex;
                this.queueItems[this.minHeap[parentIndex].Value].HeapIndex = heapIndex;

                this.minHeap.Swap(heapIndex, parentIndex);
                heapIndex = parentIndex;
            }
        }

        public void IncreasePriority(int index, TPriority priority)
        {
            int heapIndex = this.queueItems[index].HeapIndex;

            if (this.minHeap[heapIndex].Key.CompareTo(priority) <= 0)
            {
                return;
            }

            this.minHeap.UpdateKey(heapIndex, priority);
            this.Heapify(heapIndex);
        }

        public void UpdatePriority(int index, TPriority priority)
        {
            this.DecreasePriority(index, priority);
            this.IncreasePriority(index, priority);
        }

        public void Insert(Item item, TPriority priority)
        {
            this.queueItems.Add(item);
            
            this.minHeap.Insert(priority, this.queueItems.Count - 1);
            //this.DecreasePriority()
        }

        private void Heapify(int index)
        {
            int leftChild = this.LeftChild(index);
            int rightChild = this.RightChild(index);
            int minimun = index;

            if (leftChild < this.minHeap.Count
                && this.minHeap[index].Key.CompareTo(this.minHeap[leftChild].Key) > 0)
            {
                minimun = leftChild;
            }

            if (rightChild < this.minHeap.Count
                && this.minHeap[minimun].Key.CompareTo(this.minHeap[rightChild].Key) > 0)
            {
                minimun = rightChild;
            }

            if (minimun != index)
            {
                this.queueItems[this.minHeap[index].Value].HeapIndex = minimun;
                this.queueItems[this.minHeap[minimun].Value].HeapIndex = index;

                this.minHeap.Swap(index, minimun);

                this.Heapify(minimun);
            }
        }

        private int LeftChild(int nodeIndex)
        {
            // Left shift by 1 bit = 2*nodeIndex
            return nodeIndex << nodeIndex + 1;
        }

        private int RightChild(int nodeIndex)
        {
            // Left shift by 1 bit = 2*nodeIndex
            return nodeIndex << nodeIndex + 2;
        }

        private int Parent(int nodeIndex)
        {
            // Left shift by 1 bit = nodeIndex/2
            return nodeIndex >> 1;
        }
    }
}
