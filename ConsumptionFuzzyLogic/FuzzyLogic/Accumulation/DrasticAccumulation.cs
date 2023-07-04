using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Accumulation
{
    public class DrasticAccumulation : Accumulation
    {
        public override double Calculate(List<double> conclusions)
        {
            double sum = conclusions.Sum();
            double max = conclusions.Max();

            if (sum == max)
            {
                return max;
            }

            return 1;
        }
    }
}
