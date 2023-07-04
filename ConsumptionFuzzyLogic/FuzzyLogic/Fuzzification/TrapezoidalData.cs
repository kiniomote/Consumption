using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Fuzzification
{
    public class TrapezoidalData
    {
        public double LeftDown { get; set; }
        public double LeftTop { get; set; }
        public double RightTop { get; set; }
        public double RightDown { get; set; }

        public double Calculate(double current)
        {
            if (current <= LeftDown || current >= RightDown)
            {
                return 0;
            }
            else if (current >= LeftTop && current <= RightTop)
            {
                return 1;
            }
            else if (current > LeftDown && current < LeftTop)
            {
                return (current - LeftDown) / (LeftTop - LeftDown);
            }
            else
            {
                return 1 - (current - RightTop) / (RightDown - RightTop);
            }
        }
    }
}
