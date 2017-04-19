/*
 * There are  strings. Each string's length is no more than  characters. There are also  queries. For each query, you are given a string, and you need to find out how many times this string occurred previously.

Input Format

The first line contains , the number of strings.
The next  lines each contain a string.
The nd line contains , the number of queries.
The following  lines each contain a query string.

Constraints

Sample Input

4
aba
baba
aba
xzxb
3
aba
xzxb
ab
Sample Output

2
1
0
Explanation

Here, "aba" occurs twice, in the first and third string. The string "xzxb" occurs once in the fourth string, and "ab" does not occur at all.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStatements
{
    public class SparseArrays
    {
        private string[] inputArray;
        private string[] queries;

        private Dictionary<string, int> stringCount;

        public SparseArrays(string[] inputArray, string[] queries)
        {
            this.inputArray = inputArray;
            this.queries = queries;

            for (int i = 0; i < queries.Length; i++)
            {
                //string input = Console.ReadLine();
                //input = input.Substring(0, Math.Min(input.Length, 20));

                //queries[i] = input;

                if (!stringCount.ContainsKey(queries[i]))
                {
                    stringCount.Add(queries[i], 0);
                }
            }

            this.stringCount = new Dictionary<string, int>();
        }

        public static void QueryStringCount(string[] inputArray, Dictionary<string, int> stringCount)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                //Console.WriteLine(inputArray[i]);

                if (stringCount.ContainsKey(inputArray[i]))
                {
                    stringCount[inputArray[i]]++;
                }
            }
        }
    }
}
