using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStatements
{
    public class SumCombinations
    {
        private int sum;
        private int n;

        public SumCombinations(int sum, int n)
        {
            if (n == 0)
            {
                throw new ArgumentException("n");
            }

            this.sum = sum;
            this.n = n;
        }


        //public List<Tuple<int, int>> ReturnSumCombinations()
        //{
        //    List<Tuple<int, int>> sumCombinations = new List<Tuple<int, int>>();
        //    int num1 = sum;

        //    // Base case
        //    sumCombinations.Add(new Tuple<int, int>(num1, 0));

        //    for (int i = sum; i >= 1; i--)
        //    {
        //        sumCombinations.Add(new Tuple<int, int>(i, sum - i));
        //    }
        //}
    }
}
