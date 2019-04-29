using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Arrays;
using LeetCodeTest.Utility;

namespace LeetCodeTest.Arrays
{
    [TestClass]
    public class MoveZerosTests
    {
        [TestMethod]
        public void MoveZerosResultsinSuccess()
        {
            var input = new int[] { 0, 1, 0, 3, 12 };
            var expectedResult = new int[] { 1, 3, 12, 0, 0 };

            new MoveZeros().MoveZeroesSolution(input);

            var result = ArrayEquivalence.sequencesEqual(input, expectedResult);

            Assert.IsTrue(result);
        }
    }
}
