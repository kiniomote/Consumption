using ConsumptionFuzzyLogic.FuzzyLogic.Accumulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Fuzzification
{
    public class UnionOfFuzzySets
    {
        public List<ActivatedFuzzySet> ActivatedFuzzySets { get; set; }

        private IAccumulation _accumulation { get; set; }

        public UnionOfFuzzySets(IAccumulation accumulation)
        {
            ActivatedFuzzySets = new List<ActivatedFuzzySet>();
            _accumulation = accumulation;
        }

        public double Calculate(double current)
        {
            List<double> values = new List<double>();

            foreach(ActivatedFuzzySet activatedFuzzySet in ActivatedFuzzySets)
            {
                values.Add(activatedFuzzySet.Calculate(current));
            }

            return _accumulation.Calculate(values);
        }
    }
}
