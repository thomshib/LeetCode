using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.DynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeTest.DynamicProgramming
{

    [TestClass]
    public  class BestTimetoBuyandSellStockTests
    {

        [TestMethod]
        public void BestTimetoBuyandSellStock_Success()
        {
            var expectedResult = 5;   // 6 - 1
            var prices = new int[] {7, 1, 5, 3, 6, 4};

            var result = new BestTimetoBuyandSellStock().MaxProfit(prices);

            Assert.AreEqual(result, expectedResult);

        }


        [TestMethod]
        public void BestTimetoBuyandSellStock_ResultsInZeroProfit()
        {
            var expectedResult = 0;   
            var prices = new int[] { 7, 6, 4, 3, 1 };

            var result = new BestTimetoBuyandSellStock().MaxProfit(prices);

            Assert.AreEqual(result, expectedResult);

        }
    }
}
