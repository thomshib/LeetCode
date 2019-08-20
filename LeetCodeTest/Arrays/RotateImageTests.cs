using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Arrays;
using LeetCodeTest.Utility;

namespace LeetCodeTest.Arrays
{
    [TestClass]
    public class RotateImageTests
    {
        [TestMethod]
        public void RotateImageTests_Success()
        {
            var input = new int[][]{
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9}
            };

            var expectedResult = new int[][]{
                new int[]{7,4,1},
                new int[]{8,5,2},
                new int[]{9,6,3}
            };

            new RotateImage().Rotate(input);

            var areEqual = ArrayEquivalence.sequencesEqual(input,expectedResult);

            Assert.IsTrue(areEqual);

        }
    }

}