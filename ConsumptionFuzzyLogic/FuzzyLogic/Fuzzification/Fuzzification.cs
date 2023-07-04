using ConsumptionFuzzyLogic.FuzzyLogic.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Fuzzification
{
    public class Fuzzification
    {
        public FuzzificationData FuzzificationData { get; set; }

        public Fuzzification(FuzzificationData fuzzificationData)
        {
            FuzzificationData = fuzzificationData;
        }

        public Dictionary<Grade, double> GetFuzzy(double current)
        {
            Dictionary<Grade, double> fuzzySet = new Dictionary<Grade, double>()
            {
                [Grade.Small] = FuzzificationData.Small.Calculate(current),
                [Grade.Medium] = FuzzificationData.Medium.Calculate(current),
                [Grade.Big] = FuzzificationData.Big.Calculate(current),
            };

            return fuzzySet;
        }
    }
}
