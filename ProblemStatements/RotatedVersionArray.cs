using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStatements
{
    public class RotatedVersionArray
    {
        private int[] input1;
        private int[] input2;

        public RotatedVersionArray(int[] input1, int[] input2)
        {
            this.input1 = input1;
            this.input2 = input2;
        }

        public bool IsRotatedVersionArrays()
        {
            if (this.input1.Length != this.input2.Length)
            {
                return false;
            }

            Dictionary<int, int> frequencyCount = new Dictionary<int, int>();

            for (int i = 0; i < input1.Length; i++)
            {
                if (!frequencyCount.ContainsKey(this.input1[i]))
                {
                    frequencyCount.Add(this.input1[i], 1);
                }
                else
                {
                    frequencyCount[this.input1[i]]++;
                }
            }

            for (int j = 0; j < input1.Length; j++)
            {
                if (!frequencyCount.ContainsKey(this.input2[j])
                    || (frequencyCount.ContainsKey(this.input2[j]) && frequencyCount[this.input2[j]] == 0))
                {
                    return false;
                }

                frequencyCount[this.input2[j]]--;
            }

            return true;
        }

        public static void TestCase()
        {
            int[] input1 = new int[] { 1, 2, 2, 5, 6, 7, 8 };
            int[] input2 = new int[] { 5, 6, 7, 8, 1, 2, 3 };

            RotatedVersionArray obj = new RotatedVersionArray(input1, input2);

            Console.WriteLine("Is input2 rotate array of input1 :{0}",obj.IsRotatedVersionArrays());
        }
    }
}
