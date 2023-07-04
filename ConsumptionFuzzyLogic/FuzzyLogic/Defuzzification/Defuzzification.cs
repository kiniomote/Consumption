using ConsumptionFuzzyLogic.FuzzyLogic.Fuzzification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Defuzzification
{
    public abstract class Defuzzification : IDefuzzification
    {
        public abstract double Calculate(UnionOfFuzzySets unionOfFuzzySets);
    }
}
