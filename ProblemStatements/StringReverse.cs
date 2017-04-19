using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStatements
{
    public class StringReverse
    {
        public char[] inputString
        {
            get;
            private set;
        }

        public StringReverse(char[] inputString)
        {
            this.inputString = inputString;
        }

        public void ReverseIterative()
        {
            for (int i = 0; i < (this.inputString.Length) / 2; i++)
            {
                char temp = this.inputString[this.inputString.Length - 1 - i];
                this.inputString[this.inputString.Length - 1 - i] = this.inputString[i];
                this.inputString[i] = temp;
            }
        }

        public void ReverseRecursive(int i)
        {
            if (i >= (this.inputString.Length) / 2)
            {
                return;
            }

            char temp = this.inputString[this.inputString.Length - 1 - i];
            this.inputString[this.inputString.Length - 1 - i] = this.inputString[i];
            this.inputString[i] = temp;

            ReverseRecursive(i + 1);
        }
    }
}
