using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Fuzzification
{
    public class ZLineData
    {
        public double Top { get; set; }
        public double Down { get; set; }

        public double Calculate(double current)
        {
            if (current <= Top)
            {
                return 1;
            }
            else if (current >= Down)
            {
                return 0;
            }
            else
            {
                return 1 - (current - Top) / (Down - Top);
            }
        }
    }
}
