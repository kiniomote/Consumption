using ConsumptionFuzzyLogic.FuzzyLogic.Fuzzification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Defuzzification
{
    public class RightDefuzzification : Defuzzification
    {
        private double _min;
        private double _max;

        public RightDefuzzification(double min, double max)
        {
            _min = min;
            _max = max;
        }

        public override double Calculate(UnionOfFuzzySets unionOfFuzzySets)
        {
            List<double> mode = Mode(unionOfFuzzySets);

            double result = 0;

            if (mode.Count > 0)
            {
                result = mode.Max();
            }

            return Math.Round(result, 2);
        }

        private List<double> Mode(UnionOfFuzzySets unionOfFuzzySets)
        {
            double n = 100;
            double h = (_max - _min) / n;
            double x = _min;

            Dictionary<double, int> countValues = new Dictionary<double, int>();
            Dictionary<double, double> lastIn = new Dictionary<double, double>();

            while (x < _max)
            {
                double value = unionOfFuzzySets.Calculate(x);

                if (countValues.ContainsKey(value))
                {
                    countValues[value]++;
                    lastIn[value] = x;
                } 
                else
                {
                    countValues.Add(value, 1);
                    lastIn.Add(value, x);
                }

                x += h;
            }

            List<double> modes = new List<double>();

            foreach(var f in countValues)
            {
                if (f.Value > 5 && f.Key != 0)
                {
                    modes.Add(lastIn[f.Key]);
                }
            }

            return modes;
        }
    }
}
