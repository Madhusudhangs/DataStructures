using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Arrays
{
    public class MostFrequentElement
    {
        private int[] inputArray;
        private Dictionary<int, int> elementFrequencyHash;


        public MostFrequentElement(int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException("inputArray");
            }

            this.elementFrequencyHash = new Dictionary<int, int>();
            this.inputArray = inputArray;
        }

        public int FindMostFrequentNumber()
        {
            int frequentElement = this.inputArray[0];
            int maxAppearenceCount = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (!elementFrequencyHash.ContainsKey(this.inputArray[i]))
                {
                    this.elementFrequencyHash.Add(this.inputArray[i], 1);
                }
                else
                {
                    this.elementFrequencyHash[this.inputArray[i]] = this.elementFrequencyHash[this.inputArray[i]] + 1;
                }

                if (this.elementFrequencyHash[this.inputArray[i]] > maxAppearenceCount)
                {
                    maxAppearenceCount = this.elementFrequencyHash[this.inputArray[i]];
                    frequentElement = this.inputArray[i];
                }
            }

            return frequentElement;
        }
    }
}
