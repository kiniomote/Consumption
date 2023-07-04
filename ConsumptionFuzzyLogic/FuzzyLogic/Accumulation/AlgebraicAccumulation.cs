using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Accumulation
{
    public class AlgebraicAccumulation : Accumulation
    {
        public override double Calculate(List<double> conclusions)
        {
            double multiplication = 1;
            double sum = 0;

            foreach (double conclusion in conclusions)
            {
                multiplication *= conclusion;
                sum += conclusion;
            }

            return Math.Min(sum - multiplication, 1);
        }
    }
}
