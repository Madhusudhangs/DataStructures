/*
 * 
 * You are given a list of size , initialized with zeroes. You have to perform  operations on the list and output the maximum of final values of all the  elements in the list. For every operation, you are given three integers ,  and  and you have to add value  to all the elements ranging from index  to (both inclusive).

Input Format

First line will contain two integers  and  separated by a single space.
Next  lines will contain three integers ,  and  separated by a single space.
Numbers in list are numbered from  to .

Constraints

Output Format

A single line containing maximum value in the updated list.

Sample Input

5 3
1 2 100
2 5 100
3 4 100
Sample Output

200
Explanation

After first update list will be 100 100 0 0 0. 
After second update list will be 100 200 100 100 100.
After third update list will be 100 200 200 200 100.
So the required answer will be 200.
  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStatements
{
    public class AlgorithmCrush
    {
        //static void Main(String[] args)
        //{
        //    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */

        //    string[] inputSize = Console.ReadLine().Split(' ');
        //    long listSize = long.Parse(inputSize[0]);
        //    long[] list = new long[listSize + 1];

        //    int queryCount = int.Parse(inputSize[1]);
        //    long[,] queries = new long[queryCount, 3];

        //    for (int i = 0; i < queryCount; i++)
        //    {
        //        string[] queryInputs = Console.ReadLine().Split(' ');
        //        queries[i, 0] = long.Parse(queryInputs[0]);
        //        queries[i, 1] = long.Parse(queryInputs[1]);
        //        queries[i, 2] = long.Parse(queryInputs[2]);
        //    }

        //    Console.WriteLine(ReturnMaxOfNOperations(list, queries));
        //}

        public static long ReturnMaxOfNOperations(long[] list, long[,] queries)
        {
            long maxResult = 0;

            for (int i = 0; i < queries.GetLength(0); i++)
            {
                for (long j = queries[i, 0]; j <= queries[i, 1]; j++)
                {
                    list[j] += queries[i, 2];

                    if (maxResult < list[j])
                    {
                        maxResult = list[j];
                    }
                }
            }

            return maxResult;
        }
    }
}
