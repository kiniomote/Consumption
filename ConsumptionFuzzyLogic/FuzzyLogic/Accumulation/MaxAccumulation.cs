using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Accumulation
{
    public class MaxAccumulation : Accumulation
    {
        public override double Calculate(List<double> conclusions)
        {
            return conclusions.Max();
        }
    }
}
