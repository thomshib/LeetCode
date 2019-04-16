using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.DynamicProgramming;

namespace LeetCodeTest.DynamicProgramming
{

    [TestClass]
    public class DecodeWaysTests
    {


        [TestMethod]
        public void DecodeWaysTests_Recursive_Success()
        {
            var expectedResult = 3;  //(2,2,6), (22,6), (2,26)
            string encodedText = "226";

            var result = new DecodeWays().DecodeWaysRecursiveSolver(encodedText);

            Assert.AreEqual(result, expectedResult);

        }


        [TestMethod]
        public void DecodeWaysTests_Iterative_Success()
        {
            var expectedResult = 3;  //(2,2,6), (22,6), (2,26)
            string encodedText = "226";

            var result = new DecodeWays().DecodeWaysIterativeSolver(encodedText);

            Assert.AreEqual(result, expectedResult);

        }
    }
}
