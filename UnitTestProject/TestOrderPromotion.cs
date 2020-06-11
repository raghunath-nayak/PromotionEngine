using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Rules;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class TestOrderPromotion
    {
        RuleSet _ruleset = null;
        Dictionary<char, int> _itemPricePair = null;

        [TestInitialize]
        public void TestInitialize()
        {
            _ruleset = new RuleSet();
            Tuple<char, int>[] itemCountPairList = new Tuple<char, int>[]
            {
                new Tuple<char, int>('C',1),
                new Tuple<char, int>('D',1)
            };
            _ruleset.AddRule(new PromoRule(itemCountPairList, 30));

            _ruleset.AddRule(new PromoRule('A', 3, 130));
            _ruleset.AddRule(new PromoRule('B', 2, 45));

            _itemPricePair = new Dictionary<char, int>()
            {
                { 'A',50 },
                { 'B',30 },
                { 'C',20},
                { 'D',15 }
            };

        }

        [TestMethod]
        public void ScenarioA()
        {
            char[] itemsList = new char[] { 'A','B', 'C' };

            OrderValueCalculator orderValueCalculator = new OrderValueCalculator(itemsList, _ruleset, _itemPricePair);
            int result = orderValueCalculator.CalculateTotalOrderValue();

            Assert.AreEqual(result, 100);
        }

        [TestMethod]
        public void ScenarioB()
        {
            char[] itemsList = new char[] { 'A', 'A', 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C' };

            OrderValueCalculator orderValueCalculator = new OrderValueCalculator(itemsList, _ruleset, _itemPricePair);
            int result = orderValueCalculator.CalculateTotalOrderValue();

            Assert.AreEqual(result, 370);
        }

        [TestMethod]
        public void ScenarioC()
        {
         
         

            char[] itemsList = new char[] { 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C' ,'D'};

            OrderValueCalculator orderValueCalculator = new OrderValueCalculator(itemsList, _ruleset, _itemPricePair);
            int result = orderValueCalculator.CalculateTotalOrderValue();

            Assert.AreEqual(result, 280);
        }
    }
}
 