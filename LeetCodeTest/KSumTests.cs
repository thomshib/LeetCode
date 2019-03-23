using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode._3sum;

namespace LeetCodeTest
{
    [TestClass]
    public class KSumTests
    {
        [TestMethod]
        public void ThreeSum_Success()
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };

            var result = new KSum().ThreeSum(nums); 
        }

        [TestMethod]
        public void ThreeSumWithTwoPointers_Success()
        {

            var expectedResult = new List<List<int>>()
            {
                new List<int>(){ -1, 0, 1 },
                new List<int>(){-1, -1, 2 }
            };
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };

            var result = new KSum().ThreeSumWithTwoPointers(nums);

            var areEqual = CollectionsAreEqual.AreEqualListOfLists(result, expectedResult);
            Assert.IsTrue(areEqual);
        }


    }
}
