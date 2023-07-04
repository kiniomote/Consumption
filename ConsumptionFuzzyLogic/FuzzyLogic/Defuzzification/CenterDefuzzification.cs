using ConsumptionFuzzyLogic.FuzzyLogic.Fuzzification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Defuzzification
{
    public class CenterDefuzzification : Defuzzification
    {
        private double _min;
        private double _max;

        public CenterDefuzzification(double min, double max)
        {
            _min = min;
            _max = max;
        }

        public override double Calculate(UnionOfFuzzySets unionOfFuzzySets)
        {
            double min = _min;
            double max = _max;

            double result = Simpson(unionOfFuzzySets, min, max, true) / Simpson(unionOfFuzzySets, min, max, false);

            return Math.Round(result, 4);
        }

        private double Simpson(UnionOfFuzzySets unionOfFuzzySets, double a, double b, bool first)
        {
            double n = 78;
            double h = (b - a) / n;
            double s = 0; 
            double x = a + h;

            while (x < b)
            {
                if (first) 
                    s += 4 * x * unionOfFuzzySets.Calculate(x);
                else
                    s += 4 * unionOfFuzzySets.Calculate(x);
                x += h;
                if (first)
                    s += 2 * x * unionOfFuzzySets.Calculate(x);
                else
                    s += 2 * unionOfFuzzySets.Calculate(x);
                x += h;
            }

            s = h / 3 * (s + unionOfFuzzySets.Calculate(a) + unionOfFuzzySets.Calculate(b));
            
            return s;
        }
    }
}
