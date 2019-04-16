using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Misc;

namespace LeetCodeTest.Misc
{

    [TestClass]
    public class ContainerWithMostWaterTests
    {

        [TestMethod]
        public void MaxArea_Success()
        {
            var height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            var expectedResult = 49;
            var result = new ContainerWithMostWater().MaxArea(height);

            Assert.AreEqual(result, expectedResult);
        }
    }
}
