using PromotionEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Rules
{

            
    
    public class OrderValueCalculator
    {
        List<char> _itemsList = null;
        RuleSet _ruleset = null;

        Dictionary<char, int> _itemPricePair = null;
        public OrderValueCalculator(char[] itemsList,RuleSet ruleset, Dictionary<char, int> itemPricePair)
        {
            this._itemsList = itemsList.ToList();
            this._ruleset = ruleset;
            this._itemPricePair = itemPricePair;
        }


        private int CalculateNonPromoValue(char[] items)
        {
            int result = 0;
            foreach(var item in items)
            {
                if(_itemPricePair.ContainsKey(item))
                {
                    result += _itemPricePair[item];
                }
            }

            return result;
        }


       public int CalculateTotalOrderValue()
        {
            //calculatePromovalue;
            int promoValue = 0;
            var items = new List<char>(_itemsList);

            PromotionResult ruleResult = this._ruleset.ExecuteRules(items.ToArray());

            while (ruleResult != null)
            {
                if (ruleResult.ItemsUsed != null)
                {
                    foreach (var item in ruleResult.ItemsUsed)
                    {
                        items.Remove(item);
                    }

                    promoValue += ruleResult.Value;
                }

                ruleResult = this._ruleset.ExecuteRules(items.ToArray());
            }

            //calculate order total value;
            int totalOrderValue = promoValue + CalculateNonPromoValue(items.ToArray());

            return totalOrderValue;
        }          

    }
}
