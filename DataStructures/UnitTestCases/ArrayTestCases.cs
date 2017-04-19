using DataStructures.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.UnitTestCases
{
    public class ArrayTestCases
    {
        public static void TestFindMostFrequentElement()
        {
            int[] inputArray = new int[8] { 2, 3, 4, 3, 3, 2, 2, 2 };

            MostFrequentElement mostFrequentElement = new MostFrequentElement(inputArray);
            int result = mostFrequentElement.FindMostFrequentNumber();

            Console.WriteLine("Most Frequent element:{0}", result);
        }
    }
}
