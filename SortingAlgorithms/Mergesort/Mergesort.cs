using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Mergesort
{
    public class MergesortAlgo
    {

        private int[] inputArray;

        public MergesortAlgo(int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException("inputArray");
            }

            this.inputArray = inputArray;
        }

        public void MergeSort(int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;

                this.MergeSort(start, mid);
                this.MergeSort(mid + 1, end);

                this.Merge(start, mid, end);
            }
        }

        public void Merge(int start, int mid, int end)
        {
            int leftArrayLength = mid - start + 1;
            int rightArrayLenght = (end - (mid + 1) + 1);

            int[] leftArray = new int[leftArrayLength];
            int[] rightArray = new int[rightArrayLenght];

            int i = 0;
            int j = 0;

            for (; i < leftArrayLength; i++)
            {
                leftArray[i] = this.inputArray[i + start];
            }

            for (; j < rightArrayLenght; j++)
            {
                rightArray[j] = this.inputArray[j + mid + 1];
            }

            i = 0;
            j = 0;
            int k = start;

            while (i < leftArrayLength && j < rightArrayLenght)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    this.inputArray[k] = leftArray[i++];
                }
                else
                {
                    this.inputArray[k] = rightArray[j++];
                }

                k++;
            }

            while (i < leftArrayLength)
            {
                this.inputArray[k] = leftArray[i++];
            }

            while (j < leftArrayLength)
            {
                this.inputArray[k] = leftArray[j++];
            }
        }

        #region Test Cases

        public static void TestMergeSort()
        {
            int[] input = new int[] { 2, 1, 5, 4, 7, 3, 8, 9 };
            Console.WriteLine("Before"); ;

            input.Display();

            MergesortAlgo algoObject = new MergesortAlgo(input);
            algoObject.MergeSort(0, input.Length - 1);

            Console.WriteLine("After");
            input.Display();
        }

        #endregion
    }
}
