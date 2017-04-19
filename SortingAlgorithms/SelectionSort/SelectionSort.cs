using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class SelectionSort
    {
        private int[] inputArray;

        public SelectionSort(int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException("inputArray");
            }

            this.inputArray = inputArray;
        }

        public void Sort()
        {
            for (int i = 0; i < this.inputArray.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < this.inputArray.Length; j++)
                {
                    if (this.inputArray[i] > this.inputArray[j])
                    {
                        min = j;
                    }
                }

                this.Swap(i, min);
            }
        }

        public void Swap(int itemIndex1, int itemIndex2)
        {
            int temp = this.inputArray[itemIndex1];
            this.inputArray[itemIndex1] = this.inputArray[itemIndex2];
            this.inputArray[itemIndex2] = temp;
        }

        #region Test cases

        public static void TestCaseForSort()
        {
            int[] input = new int[] { 5, 3, 2, 2, 1 };

            Console.WriteLine("Before");
            input.Display();

            SelectionSort sortObj = new SelectionSort(input);
            sortObj.Sort();

            Console.WriteLine("--------------------");
            Console.WriteLine("After");
            input.Display();
        }

        #endregion
    }
}
