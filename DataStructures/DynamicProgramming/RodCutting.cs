using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DynamicProgramming
{
    public class RodCutting
    {
        private int numberOfCuts;
        private double[] costOfCuts;

        public RodCutting(int numberOfCuts, double[] costOfCuts)
        {
            if(costOfCuts == null)
            {
                throw new ArgumentNullException("costOfCuts");
            }

            this.numberOfCuts = numberOfCuts;
            this.costOfCuts = costOfCuts;
        }


    }
}
