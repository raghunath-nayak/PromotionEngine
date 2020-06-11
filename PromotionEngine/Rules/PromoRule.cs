using PromotionEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Rules
{
    public class PromoRule : IPromoRule
    {
        
        Tuple<char, int>[] _itemCountPairList = null;
        int _price = 0;

        private bool DoesSatifyCondition(char[] itemsList)
        {
            bool result = true;
            foreach (var itemPricePair in _itemCountPairList)
            {
                char itemName = itemPricePair.Item1;
                int setSize = itemPricePair.Item2;

                int itemCount = itemsList.Count(d => d == itemName);

                if (itemCount < setSize)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public PromotionResult Evaluate(char[] itemsList)
        {
            PromotionResult result = null;
            List<char> matchingItems = new List<char>();
            int price = 0;
            List<char> items = new List<char>(itemsList);

            while (DoesSatifyCondition(items.ToArray()))
            {
                foreach (var itemPricePair in _itemCountPairList)
                {
                    char itemName = itemPricePair.Item1;
                    int setSize = itemPricePair.Item2;
                    int iter = 0;
                    while (iter++ < setSize)
                    {
                        matchingItems.Add(itemName);
                        items.Remove(itemName);
                    }                    
                }                
             
                price += this._price;
            }

            if (matchingItems.Count > 0)
            {
                if (result == null) result = new PromotionResult();
                result.ItemsUsed = matchingItems.ToArray();
                result.Value = price;
            }

            return result;
        }

        public PromoRule(char item, int count, int price)
        {
           
            this._itemCountPairList = new Tuple<char, int>[]
            {
                new Tuple<char, int>(item,count)
            };

            this._price = price;
           
        }

        public PromoRule(Tuple<char,int>[] itemCountPairList,int price)
        {
            this._itemCountPairList = itemCountPairList;
                this._price = price;
        }
    }
}
 