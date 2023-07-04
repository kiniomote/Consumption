using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Activation
{
    public interface IActivation
    {
         double Calculate(double c, double u);
    }
}
