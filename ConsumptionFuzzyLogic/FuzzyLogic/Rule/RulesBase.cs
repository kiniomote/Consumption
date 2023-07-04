using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumptionFuzzyLogic.FuzzyLogic.Rule
{
    public class RulesBase
    {
        public List<Rule> Rules { get; set; }

        public RulesBase()
        {
            Rules = new List<Rule>();
        }

        public Rule FindRule(Grade level, Grade consumption)
        {
            foreach (Rule rule in Rules)
            {
                if (rule.Fit(level, consumption))
                {
                    return rule;
                }
            }

            return null;
        }
    }
}
