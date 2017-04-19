using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public class MinHeap : Heap
    {
        public MinHeap(int heapSize, int[] inputArray)
            : base(heapSize, inputArray)
        {
        }

        protected override void Heapify(int index)
        {
            int leftChild = this.LeftChild(index);
            int rightChild = this.RightChild(index);
            int minimun = index;

            if (leftChild < this.heapSize
                && this.inputArray[index] > leftChild)
            {
                minimun = leftChild;
            }

            if (rightChild < this.heapSize
                && this.inputArray[minimun] > rightChild)
            {
                minimun = rightChild;
            }

            if (minimun != index)
            {
                this.Swap(index, minimun);
                this.Heapify(minimun);
            }
        }

        public int HeapMin()
        {
            return this.inputArray[0];
        }

        public int ExtractHeapMin()
        {
            return this.ExtractTopMostHeapElement();
        }

        public override void IncreaseKey(int index, int key)
        {
            if (this.inputArray[index] >= key)
            {
                throw new InvalidCastException("New key value should be less than the current heap index value");
            }

            this.inputArray[index] = key;

            this.Heapify(index);    
        }

        public override void DecreaseKey(int index, int key)
        {
            if (this.inputArray[index] <= key)
            {
                throw new InvalidCastException("New key value should be greater than the current heap index value");
            }

            this.inputArray[index] = key;

            int maxItemIndex = 0;

            while (index > maxItemIndex && this.inputArray[this.Parent(index)] < this.inputArray[index])
            {
                this.Swap(this.Parent(index), index);
                index = this.Parent(index);
            }
        }
    }
}
