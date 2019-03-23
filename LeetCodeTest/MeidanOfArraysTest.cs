using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.MedianArrays;

namespace LeetCodeTest
{
    [TestClass]
    public class MeidanOfArraysTest
    {

        [TestMethod]
        public void MedianOfArrays_Succcess()
        {
            int[] input1 = new int[] { 1, 3, 8, 9, 15 };
            int[] input2 = new int[] { 7, 11, 18, 19, 21, 25 };

            var expectedResult = 11.0;

            var result = new MedianOfArrays().FindMedianOfArrays(input1, input2);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void MedianOfArrays_NegativeINF_EdgeCase_Succcess()
        {
            int[] input1 = new int[] { 23,26,31,35 };
            int[] input2 = new int[] { 3,5,7,9,11,16 };

            var expectedResult = 13;

            var result = new MedianOfArrays().FindMedianOfArrays(input1, input2);

            Assert.AreEqual(result, expectedResult);
        }
    }
}
