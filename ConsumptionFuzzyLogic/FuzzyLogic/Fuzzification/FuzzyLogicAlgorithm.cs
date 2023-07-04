using ConsumptionFuzzyLogic.FuzzyLogic.Accumulation;
using ConsumptionFuzzyLogic.FuzzyLogic.Activation;
using ConsumptionFuzzyLogic.FuzzyLogic.Defuzzification;
using ConsumptionFuzzyLogic.FuzzyLogic.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Fuzzification
{
    public class FuzzyLogicAlgorithm
    {
        public RulesBase RulesBase { get; set; }

        public FuzzificationData LevelFuzzificationData { get; set; }
        public FuzzificationData ConsumptionFuzzificationData { get; set; }
        public FuzzificationData InflowFuzzificationData { get; set; }

        public IActivation ActivationFunction { get; set; }
        public IAccumulation AccumulationFunction { get; set; }
        public IDefuzzification DefuzzificationFunction { get; set; }

        private List<ActivatedFuzzySet> _activatedFuzzySets { get; set; }
        private UnionOfFuzzySets _unionOfFuzzySets { get; set; }

        public FuzzyLogicAlgorithm()
        {
            RulesBase = new RulesBase();

            LevelFuzzificationData = new FuzzificationData();
            ConsumptionFuzzificationData = new FuzzificationData();
            InflowFuzzificationData = new FuzzificationData();

            ActivationFunction = new MinActivation();
            AccumulationFunction = new BorderyAccumulation();
            DefuzzificationFunction = new CenterDefuzzification(0.08, 0.5);

            _activatedFuzzySets = new List<ActivatedFuzzySet>();
            _unionOfFuzzySets = new UnionOfFuzzySets(AccumulationFunction);
        }

        public double Calculate(double level, double consumption)
        {
            DegreeOfTruth levelDegree = Fuzzification(level, LevelFuzzificationData);
            DegreeOfTruth consumptionDegree = Fuzzification(consumption, ConsumptionFuzzificationData);

            Aggregation(levelDegree, consumptionDegree);

            Activation();

            Accumulation();

            double inflow = Defuzzification();

            return inflow;
        }

        public double CalculateUnionOfFuzzySets(double current)
        {
            return _unionOfFuzzySets.Calculate(current);
        }

        private DegreeOfTruth Fuzzification(double current, FuzzificationData fuzzificationData)
        {
            Fuzzification fuzzification = new Fuzzification(fuzzificationData);
            DegreeOfTruth degreeOfTruth = new DegreeOfTruth(fuzzification.GetFuzzy(current));

            return degreeOfTruth;
        }

        private void Aggregation(DegreeOfTruth levelDegree, DegreeOfTruth consumptionDegree)
        {
            foreach(Rule.Rule rule in RulesBase.Rules)
            {
                rule.Degree = Math.Min(levelDegree.Grades[rule.Level], consumptionDegree.Grades[rule.Consumption]);
            }
        }

        private void Activation()
        {
            _activatedFuzzySets = new List<ActivatedFuzzySet>();

            foreach (Rule.Rule rule in RulesBase.Rules)
            {
                double activated = rule.Weight * rule.Degree;
                _activatedFuzzySets.Add(new ActivatedFuzzySet(InflowFuzzificationData, ActivationFunction, activated, rule.Inflow));
            }
        }

        private void Accumulation()
        {
            _unionOfFuzzySets = new UnionOfFuzzySets(AccumulationFunction)
            {
                ActivatedFuzzySets = _activatedFuzzySets
            };
        }

        private double Defuzzification()
        {
            double result = DefuzzificationFunction.Calculate(_unionOfFuzzySets);

            return result;
        }
    }
}
