using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Accumulation
{
    public class BorderyAccumulation : Accumulation
    {
        public override double Calculate(List<double> conclusions)
        {
            double sum = 0;

            foreach (double conclusion in conclusions)
            {
                sum += conclusion;
            }

            return Math.Min(sum, 1);
        }
    }
}
