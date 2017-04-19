using DataStructures.GraphOld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.UnitTestCases
{
    public class GraphTestCases
    {
        public static void TestNumberOfIslandsProblem()
        {
            int[,] inputMatrix = new int[5, 5] { { 0, 0, 0, 0, 0 }, { 0, 1, 0, 0, 1 }, { 1, 0, 0, 1, 1 }, { 0, 0, 0, 0, 0 }, { 1, 0, 1, 0, 1 } };

            NumberOfIslandsProblem problem = new NumberOfIslandsProblem(inputMatrix);

            Console.WriteLine("Number of Islands:{0}", problem.CountNumberOfIslands());
        }
    }
}
