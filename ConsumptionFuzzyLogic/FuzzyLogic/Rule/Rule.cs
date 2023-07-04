using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Rule
{
    public enum Grade
    {
        Small,
        Medium,
        Big
    }

    public class Rule
    {
        public Grade Level { get; private set; }
        public Grade Consumption { get; private set; }
        public Grade Inflow { get; private set; }

        public double Degree { get; set; }
        public double Weight { get; private set; }

        public Rule(Grade level, Grade consumption, Grade inflow, double weight)
        {
            Level = level;
            Consumption = consumption;
            Inflow = inflow;
            Weight = weight;
        }

        public bool Fit(Grade level, Grade consumption)
        {
            return Level == level && Consumption == consumption;
        }
    }
}
