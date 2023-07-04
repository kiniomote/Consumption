using ConsumptionFuzzyLogic.FuzzyLogic.Activation;
using ConsumptionFuzzyLogic.FuzzyLogic.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Fuzzification
{
    public class ActivatedFuzzySet
    {
        public IActivation Activation { get; private set; }
        public Fuzzification Fuzzification { get; private set; }
        public Grade Grade { get; private set; }

        public double Coefficient { get; set; }

        public ActivatedFuzzySet(FuzzificationData fuzzificationData, IActivation activation, double coefficient, Grade grade)
        {
            Fuzzification = new Fuzzification(fuzzificationData);
            Grade = grade;
            Activation = activation;
            Coefficient = coefficient;
        }

        public double Calculate(double current)
        {
            double result = 0;

            switch (Grade)
            {
                case Grade.Small:
                    result = Activation.Calculate(Coefficient, Fuzzification.FuzzificationData.Small.Calculate(current));
                    break;
                case Grade.Medium:
                    result = Activation.Calculate(Coefficient, Fuzzification.FuzzificationData.Medium.Calculate(current));
                    break;
                case Grade.Big:
                    result = Activation.Calculate(Coefficient, Fuzzification.FuzzificationData.Big.Calculate(current));
                    break;
            }

            return result;
        }
    }
}
