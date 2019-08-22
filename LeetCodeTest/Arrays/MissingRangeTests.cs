using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Arrays;
using LeetCodeTest.Utility;

namespace LeetCodeTest.Arrays
{
     [TestClass]
    public class MissingRangeTests
    {
         [TestMethod]
        public void MissingRangeTests_Success()
        {
            int[] nums = new int[]{0, 1, 3, 50, 75};
            List<string> expectedResult = new List<string>(){"2", "4->49", "51->74", "76->99"};
            var result = new MissingRanges().FindMissingRanges(nums,0,99);

            var areEqual = CollectionsAreEqual.AreEqual(result,expectedResult);
            Assert.IsTrue(areEqual);


            nums = new int[]{-1};
            expectedResult = new List<string>(){"-2"};
            result = new MissingRanges().FindMissingRanges(nums,-2,-1);

            areEqual = CollectionsAreEqual.AreEqual(result,expectedResult);
            Assert.IsTrue(areEqual);

        }
    }
}