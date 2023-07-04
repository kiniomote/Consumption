using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Activation
{
    public class ProdActivation : Activation
    {
        public override double Calculate(double c, double u)
        {
            return c * u;
        }
    }
}
