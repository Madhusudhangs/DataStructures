using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.BubbleSort
{
    public class BubbleSort
    {
        private int[] inputArray;

        public BubbleSort(int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException("inputArray", "Input array can't be null");
            }

            this.inputArray = inputArray;
        }

        public void Sort()
        {
            for (int i = 0; i < this.inputArray.Length - 1; i++)
            {
                for (int j = 0; j < this.inputArray.Length - i - 1; j++)
                {
                    if (this.inputArray[j] > this.inputArray[j + 1])
                    {
                        this.Swap(j, j + 1);
                    }
                }
            }
        }

        public void OptimisedSort()
        {
            for (int i = 0; i < this.inputArray.Length - 1; i++)
            {
                bool isSorted = true;

                for (int j = 0; j < this.inputArray.Length - i - 1; j++)
                {
                    if (this.inputArray[j] > this.inputArray[j + 1])
                    {
                        this.Swap(j, j + 1);
                        isSorted = false;
                    }
                }

                if (isSorted)
                {
                    break;
                }
            }
        }

        public void Swap(int itemIndex1, int itemIndex2)
        {
            int temp = this.inputArray[itemIndex1];
            this.inputArray[itemIndex1] = this.inputArray[itemIndex2];
            this.inputArray[itemIndex2] = temp;
        }

        #region Test cases
        public static void TestCaseSort()
        {
            int[] input = new int[] { 5, 4, 3, 2, 1 };
            Console.WriteLine("Before:");
            input.Display();

            BubbleSort sortObj = new BubbleSort(input);

            sortObj.Sort();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("After:");
            input.Display();
        }

        public static void TestCaseOptimizedSort()
        {
            int[] input = new int[] { 1, 2, 3, 5, 4 };

            BubbleSort sortObj = new BubbleSort(input);
            sortObj.OptimisedSort();

            Console.WriteLine("After");
            input.Display();
        }
        #endregion
    }
}
