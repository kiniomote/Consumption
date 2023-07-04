using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Activation
{
    public class AverageActivation : Activation
    {
        public override double Calculate(double c, double u)
        {
            return 0.5 * (c + u);
        }
    }
}
