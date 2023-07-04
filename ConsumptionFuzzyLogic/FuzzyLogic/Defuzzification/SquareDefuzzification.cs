using ConsumptionFuzzyLogic.FuzzyLogic.Fuzzification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Defuzzification
{
    public class SquareDefuzzification : Defuzzification
    {
        private double _min;
        private double _max;

        public SquareDefuzzification(double min, double max)
        {
            _min = min;
            _max = max;
        }

        public override double Calculate(UnionOfFuzzySets unionOfFuzzySets)
        {
            double result = CalculateCenter(unionOfFuzzySets);

            return result;
        }

        private double CalculateCenter(UnionOfFuzzySets unionOfFuzzySets)
        {
            double n = 60;
            double h = (_max - _min) / n;
            double x = _min;

            double minDiff = 10;
            double result = 0;

            while (x < _max)
            {
                double left = Simpson(unionOfFuzzySets, _min, x);
                double right = Simpson(unionOfFuzzySets, x, _max);

                double difference = Math.Abs(left - right);
                if (difference < minDiff)
                {
                    minDiff = difference;
                    result = x;
                }

                x += h;
            }

            return result;
        }

        private double Simpson(UnionOfFuzzySets unionOfFuzzySets, double a, double b)
        {
            double n = 100;
            double h = (b - a) / n;
            double s = 0;
            double x = a + h;

            while (x < b)
            {
                s += 4 * unionOfFuzzySets.Calculate(x);
                x += h;
                s += 2 * unionOfFuzzySets.Calculate(x);
                x += h;
            }

            s = h / 3 * (s + unionOfFuzzySets.Calculate(a) + unionOfFuzzySets.Calculate(b));

            return s;
        }
    }
}
