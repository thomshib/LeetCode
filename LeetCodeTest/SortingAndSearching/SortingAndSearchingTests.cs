using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.SortingAndSearching;

namespace LeetCodeTest.SortingAndSearching
{

    [TestClass]
    public class SortingAndSearchingTests
    {
        [TestMethod]
        public void DivideTwoIntegersSuccess()
        {

            int divident = 15;
            int divisor = 3;

            var result = new DivideTwoIntegers().Divide(divident, divisor);

            Assert.AreEqual(result, 5);

        }
    }
}
