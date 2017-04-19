/*
 * 
Create a list, , of  empty sequences, where each sequence is indexed from  to . The elements within each of the sequences also use -indexing.
Create an integer, , and initialize it to .
The  types of queries that can be performed on your list of sequences () are described below:
Query: 1 x y
Find the sequence, , at index  in .
Append integer  to sequence .
Query: 2 x y
Find the sequence, , at index  in .
Find the value of element  in  (where  is the size of ) and assign it to .
Print the new value of  on a new line
Task 
Given , , and  queries, execute each query.

Note:  is the bitwise XOR operation, which corresponds to the ^ operator in most languages. Learn more about it on Wikipedia.

Input Format

The first line contains two space-separated integers,  (the number of sequences) and  (the number of queries), respectively. 
Each of the  subsequent lines contains a query in the format defined above.

Constraints

It is guaranteed that query type  will never query an empty sequence or index.
Output Format

For each type  query, print the updated value of  on a new line.

Sample Input

2 5
1 0 5
1 1 7
1 0 3
2 1 0
2 1 1
Sample Output

7
3
Explanation

Initial Values: 

Query 0: Append  to sequence . 

Query 1: Append  to sequence . 

Query 2: Append  to sequence . 

Query 3: Assign the value at index  of sequence  to , print .  
7

Query 4: Assign the value at index  of sequence  to , print .  
3
*/
  
    using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    //static void Main(String[] args)
    //{
    //    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */

    //    string[] seqAndQueryCount = Console.ReadLine().Split(' ');

    //    int sequenceCount = int.Parse(seqAndQueryCount[0]);
    //    int queryCount = int.Parse(seqAndQueryCount[1]);

    //    List<List<int>> query = new List<List<int>>();

    //    for (int i = 0; i < queryCount; i++)
    //    {
    //        string[] queryTxt = Console.ReadLine().Split(' ');

    //        List<int> q = new List<int>();

    //        q.Add(int.Parse(queryTxt[0]));
    //        q.Add(int.Parse(queryTxt[1]));
    //        q.Add(int.Parse(queryTxt[2]));

    //        query.Add(q);
    //    }


    //    List<List<int>> seqList = new List<List<int>>(sequenceCount);

    //    for (int k = 0; k < sequenceCount; k++)
    //    {
    //        seqList.Add(new List<int>());
    //    }

    //    int lastAns = 0;

    //    for (int j = 0; j < queryCount; j++)
    //    {
    //        int seq = (query[j][1] ^ lastAns) % sequenceCount;

    //        if (seqList[seq] == null)
    //        {
    //            seqList[seq] = new List<int>();
    //        }

    //        if (query[j][0] == 1)
    //        {
    //            seqList[seq].Add(query[j][2]);
    //        }
    //        else if (query[j][0] == 2)
    //        {
    //            int temp = query[j][2] % (seqList[seq].Count);
    //            lastAns = seqList[seq][temp];

    //            Console.WriteLine("{0}", lastAns);
    //        }
    //    }
    //}
}