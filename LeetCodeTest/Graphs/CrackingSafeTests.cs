using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Graphs;

namespace LeetCodeTest.Graphs
{
    [TestClass]
    public class CrackingSafeTests
    {
        [TestMethod]
        public void CrackSafeTest()
        {
            int n = 2;
            int k = 2;

            var expectedResult = "00110";

            var result = new CrackingSafe().CrackSafe(n, k);

            Assert.AreEqual(result, expectedResult);
        }
    }
}
