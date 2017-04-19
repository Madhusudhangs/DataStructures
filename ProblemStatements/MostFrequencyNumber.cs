using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStatements
{
    public class MostFrequencyNumber
    {
        private int[] input;

        public MostFrequencyNumber(int[] input)
        {
            this.input = input;
        }

        public void MaxFrequencyNumber()
        {
            Dictionary<int, int> inputFrequencyCount = new Dictionary<int, int>();
            int max = 1, number = this.input[0];

            for (int i = 0; i < this.input.Length; i++)
            {
                if(!inputFrequencyCount.ContainsKey(this.input[i]))
                {
                    inputFrequencyCount.Add(this.input[i], 1);
                }

                inputFrequencyCount[this.input[i]]++;
                
                if(inputFrequencyCount[this.input[i]] > max)
                {
                    max = inputFrequencyCount[this.input[i]];
                    number = this.input[i];
                }
            }

            Console.WriteLine(number);
        }

        public static void TestMaxFrequencyNumber()
        {
            MostFrequencyNumber testcase = new MostFrequencyNumber(new int[] { 3, 3, 3, 4, 4,4,4, 5, 1 });
            testcase.MaxFrequencyNumber();

            MostFrequencyNumber testcase1 = new MostFrequencyNumber(new int[] { 3, 3, 4, 4, 5, 1 });
            testcase1.MaxFrequencyNumber();
        }
    }
}
