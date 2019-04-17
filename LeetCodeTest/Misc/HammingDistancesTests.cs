using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Misc;

namespace LeetCodeTest.Misc
{
    [TestClass]
    public class HammingDistancesTests
    {
        [TestMethod]
        public void HamminDistanceResultsinSuccess()
        {
            var expectedResult = 2;

            var result = new HammingDistances().HammingDistance(1, 4);

            Assert.AreEqual(result, expectedResult);
        }
    }
}
