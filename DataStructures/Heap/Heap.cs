using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public abstract class Heap
    {
        protected int heapSize;

        protected int inputArraySize;

        //protected int[] inputArray;

        protected List<int> inputArray;

        public Heap()
            : this(0, null)
        {
        }

        public Heap(int heapSize, int[] inputArray)
        {
            this.heapSize = heapSize;

            if (inputArray != null
                && inputArray.Any())
            {
                this.inputArray = new List<int>(inputArray);
            }

            this.inputArraySize = this.inputArray.Count;
        }

        protected abstract void Heapify(int index);

        public void BuildHeap(Heap heap)
        {
            if (heap != null)
            {
                for (int i = this.heapSize / 2; i >= 0; i--)
                {
                    this.Heapify(i);
                }
            }
        }

        public void HeapSort(Heap heap)
        {
            this.BuildHeap(heap);

            for (int i = this.heapSize; i >= 1; i--)
            {
                this.Swap(0, this.heapSize - 1);
                this.heapSize--;

                this.Heapify(0);
            }
        }

        public abstract void IncreaseKey(int index, int key);

        public abstract void DecreaseKey(int index, int key);

        public void DeleteKey(int index)
        {
            if (index < 0 || index > this.heapSize)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }

            this.Swap(index, this.heapSize - 1);
            this.RemoveItemAt(this.heapSize - 1);

            this.Heapify(index);
        }                       

        protected int ExtractTopMostHeapElement()
        {
            if (!this.inputArray.Any())
            {
                throw new InvalidOperationException("Heap Underflow");
            }

            this.Swap(0, this.heapSize - 1);
            int topMostItem = this.RemoveItemAt(this.heapSize - 1);

            this.Heapify(0);

            return topMostItem;
        }


        protected void Swap(int index1, int index2)
        {
            int temp = this.inputArray[index1];
            this.inputArray[index1] = this.inputArray[index2];
            this.inputArray[index2] = temp;
        }

        protected int LeftChild(int nodeIndex)
        {
            // Left shift by 1 bit = 2*nodeIndex
            return nodeIndex << nodeIndex + 1;
        }

        protected int RightChild(int nodeIndex)
        {
            // Left shift by 1 bit = 2*nodeIndex
            return nodeIndex << nodeIndex + 2;
        }

        protected int Parent(int nodeIndex)
        {
            // Left shift by 1 bit = nodeIndex/2
            return nodeIndex >> 1;
        }

        public void InsertItem(int key)
        {
            this.heapSize++;
            this.inputArray.Add(key);

            this.Swap(0, heapSize - 1);

            this.Heapify(0);
        }

        protected int RemoveItemAt(int index)
        {
            this.heapSize--;
            int removedItem = this.inputArray[index];

            this.inputArray.RemoveAt(index);

            return removedItem;
        }
    }
}
