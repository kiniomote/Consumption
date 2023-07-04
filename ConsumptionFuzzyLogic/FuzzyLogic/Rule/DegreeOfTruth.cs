using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Rule
{
    public class DegreeOfTruth
    {
        public Dictionary<Grade, double> Grades { get; set; }

        public DegreeOfTruth(Dictionary<Grade, double> fuzzySet)
        {
            Grades = fuzzySet;
        }
    }
}
