using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingAlgorithms.Quicksort;

namespace ProblemStatements
{
    public class SortEvenAndOdd
    {
        private int[] input;

        public SortEvenAndOdd(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            this.input = input;
        }

        /// <summary>
        /// Sorts Odd number in descending order, even number in ascending order.
        /// Time Complexity: O(nlog(n)
        /// Space Complexity: O(n)
        /// </summary>
        public void Sort()
        {
            int oddCount = 0;

            // O(n);
            for (int i = 0; i < this.input.Length; i++)
            {
                if (this.input[i] % 2 != 0)
                {
                    this.input[i] = -1 * this.input[i];
                    oddCount++;
                }               
            }

            // O(nlog(n))
            Quicksort.Sort(this.input, 0, this.input.Length - 1, false);

            // O(n-oddCount)
            for (int i = 0; i < oddCount; i++)
            {
                this.input[i] = -this.input[i];
            }
        }

        public static void TestOddAndEvenSort()
        {
            int[] input = new int[] { 7, 8, 2, 4, 5, 1, 3 };

            SortEvenAndOdd obj = new SortEvenAndOdd(input);
            obj.Sort();

            Console.WriteLine("Result");
            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
            }
        }
    }
}
