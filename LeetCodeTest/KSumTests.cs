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
        public void ThreeSumNaiveSS_Success()
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };

            var result = new KSum().ThreeSumNaive(nums); 
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

        [TestMethod]
        public void TwoSumWithHashMap_Success()
        {

            int[] nums = new int[] { 2,7,11,15 };
            var expectedResult = new List<List<int>>()
            {
                new List<int>(){ 0, 1 },
                
            };
            var result = new KSum().TwoSumWithHashMap(nums, 9);

            var areEqual = CollectionsAreEqual.AreEqualListOfLists(result, expectedResult);
            Assert.IsTrue(areEqual);

        }

        [TestMethod]
        public void TwoSumWithSortedInputArray_Success()
        {

            int[] nums = new int[] { 2, 7, 15, 11 };
            Array.Sort(nums);
            var expectedResult = new List<List<int>>()
            {
                new List<int>(){ 0, 1 },

            };
            var result = new KSum().TwoSumWithHashMap(nums, 9);

            var areEqual = CollectionsAreEqual.AreEqualListOfLists(result, expectedResult);
            Assert.IsTrue(areEqual);

        }
    }
}
