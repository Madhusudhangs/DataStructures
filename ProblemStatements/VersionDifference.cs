using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStatements
{
    public class VersionDifference
    {
        private string[] finput1;
        private string[] finput2;

        public VersionDifference(string input1, string input2)
        {
            finput1 = input1.Split('.');
            finput2 = input2.Split('.');
        }

        public string[] VersionDiff()
        {
            string[] result = new string[ this.finput2.Length];

            int i = 0;
            for (i = 0; i < result.Length; i++)
            {
                int diff = int.Parse(this.finput1[i]) - int.Parse(this.finput2[i]);
                result[i] = Math.Abs(diff).ToString();
            }

            //var maxArray = this.finput1.Length > this.finput2.Length ? this.finput1 : this.finput2;

            //for (int j = i; j < result.Length; j++)
            //{
            //    result[j] = maxArray[j];
            //}

            return result;
        }
    }
}
