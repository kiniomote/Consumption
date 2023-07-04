using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Fuzzification
{
    public class FuzzificationData
    {
        public ZLineData Small { get; set; }

        public TrapezoidalData Medium { get; set; }

        public SLineData Big { get; set; }

        public FuzzificationData()
        {
            Big = new SLineData();
            Medium = new TrapezoidalData();
            Small = new ZLineData();
        }
    }
}
