using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Accumulation
{
    public abstract class Accumulation : IAccumulation
    {
        public abstract double Calculate(List<double> conclusions);
    }
}
