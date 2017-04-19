using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStatements
{
    public class ArrayRotation
    {
        private string[] inputArray;

        public ArrayRotation(string[] inputArray)
        {
            this.inputArray = inputArray;
        }

        public static void LeftRotate(string[] inputArray, int rotationCount)
        {
            while (rotationCount > 0)
            {
                string leftMostValue = inputArray[0];

                for (int i = 1; i < inputArray.Length; i++)
                {
                    inputArray[i - 1] = inputArray[i];
                }

                inputArray[inputArray.Length - 1] = leftMostValue;

                rotationCount--;
            }
        }
    }
}
