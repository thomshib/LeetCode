using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Arrays;
using LeetCodeTest.Utility;

namespace LeetCodeTest.Arrays
{
    [TestClass]
    public class ArraysTest
    {
        [TestMethod]
        public void NextPermutationSuccess()
        {
            int[] input = new int[] { 1, 2, 3 };
            int[] expectedResult = new int[] { 1, 3, 2 };

            new NextPermutationSolution().NextPermutation(input);
            bool isEqual = ArrayEquivalence.sequencesEqual(input, expectedResult);
            Assert.IsTrue(isEqual);


            input = new int[] { 3, 2, 1 };
            expectedResult = new int[] { 1, 2, 3 };
            new NextPermutationSolution().NextPermutation(input);
            isEqual = ArrayEquivalence.sequencesEqual(input, expectedResult);
            Assert.IsTrue(isEqual);


            input = new int[] { 1, 1, 5 };
            expectedResult = new int[] { 1, 5, 1 };
            new NextPermutationSolution().NextPermutation(input);
            isEqual = ArrayEquivalence.sequencesEqual(input, expectedResult);
            Assert.IsTrue(isEqual);

        }


        [TestMethod]
        public void MultiplyStringSuccess()
        {
            string num1 = "123";
            string num2 = "456";

            var result = new MultiplyStrings().Multiply(num1, num2);

            Assert.AreEqual(result, "56088");

        }

        [TestMethod]
        public void GroupAnagramSuccess()
        {
            string[] input = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

            var expectedResult = new List<IList<string>>()
            {
                new List<string>(){"eat","tea","ate"},
                new List<string>(){"tan","nat"},
                new List<string>(){"bat"}

            };



            var result = new GroupAnagramsSolution().GroupAnagrams(input);

            var isEqual = CollectionsAreEqual.AreEqualListOfLists(result, expectedResult);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void MergeSortedArraySuccess()
        {
            int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            int m = 3;
            int[] nums2 = new int[] { 2, 5, 6 };
            int n = 3;

            int[] expectedResult = new int[] { 1, 2, 2, 3, 5, 6 };

            new MergeSortedArray().Merge(nums1, m, nums2, n);

            var isEqual = ArrayEquivalence.sequencesEqual(nums1, expectedResult);

            Assert.IsTrue(isEqual);
        }


        

            [TestMethod]
        public void ProductofArrayExceptSelfSuccess()
        {
            int[] nums = new int[] { 1, 2, 3,4};
            var expectedResult = new int[] { 24, 12, 8, 6 };

            var result = new ProductofArrayExceptSelf().ProductExceptSelf(nums);

            var isEqual = ArrayEquivalence.sequencesEqual(result, expectedResult);
            Assert.IsTrue(isEqual);

        }

        [TestMethod]
        public void SubarraySumEqualsKSuccess()
        {
            int[] input = new int[] { 1, 1, 1 };
            int k = 2;

            var result = new SubarraySumEqualsK().SubarraySum(input, k);

            Assert.AreEqual(result, 2);
        }

    }
}
