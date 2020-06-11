using PromotionEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Rules
{
    public class RuleSet
    {
        List<IPromoRule> _rulesList = new List<IPromoRule>();

        public void AddRule(IPromoRule rule)
        {
            _rulesList.Add(rule);
        }

        public void Reset()
        {
            _rulesList.Clear();
        }

        public PromotionResult ExecuteRules(char[] itemList )
        {
            PromotionResult minResult = null;
           
            foreach (var rule in _rulesList)
            {
                var ruleResult = rule.Evaluate(itemList);

                if (ruleResult != null)
                {
                    if (minResult == null) minResult = ruleResult;

                    else if (minResult.Value > ruleResult.Value)
                    {
                        minResult = ruleResult;
                    }
                }
            }

            return minResult;
        }
    }
}
