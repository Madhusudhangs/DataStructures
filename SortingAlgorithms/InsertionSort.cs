using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class InsertionSort
    {
        private int[] input;

        public InsertionSort(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            this.input = input;
        }

        public void AleternativeSort()
        {
            for (int i = 1; i < this.input.Length; i++)
            {
                int key = this.input[i];
                int j = i - 1;

                while (j >= 0 && this.input[j] > key)
                {
                    this.input[j + 1] = this.input[j];
                    j--;
                }

                this.input[j + 1] = key;
            }
        }

        public void Sort()
        {
            for (int i = 1; i < this.input.Length; i++)
            {
                int key = this.input[i];

                int j = 0;
                for (j = i - 1; j >= 0; j--)
                {
                    if (key < this.input[j])
                    {
                        this.input[j + 1] = this.input[j];
                    }
                    else
                    {
                        break;
                    }
                }

                this.input[j + 1] = key;
            }
        }

        public int BinarySearch(int key)
        {
            int start = 0;
            int end = this.input.Length;

            do
            {
                int mid = (start + end) / 2;

                if (this.input[mid] == key)
                {
                    return mid;
                }

                if (key < this.input[mid])
                {
                    start = start + 0;
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                    end = this.input.Length;
                }
            }
            while (start > end);

            return start;
        }

        #region Test Cases

        public static void TestCaseSort()
        {
            int[] input = new int[] { 5, 4, 2, 3, 1 };
            Console.WriteLine("Before");
            input.Display();

            InsertionSort sortObj = new InsertionSort(input);
            sortObj.Sort();

            Console.WriteLine("After");
            input.Display();
        }

        #endregion
    }
}
