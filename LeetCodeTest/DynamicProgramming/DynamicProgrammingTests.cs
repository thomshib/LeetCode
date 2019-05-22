using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.DynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeTest.DynamicProgramming
{
    [TestClass]
    public class DynamicProgrammingTests
    {
        [TestMethod]
        public void LongestPalindromeSuccess()
        {
            string input = "babad";
            string expectedResult = "bab";


            var result = new LongestPalindrome().LongestPalindromeString(input);

            Assert.AreEqual(result, expectedResult);


            input = "cbbd";
            expectedResult = "bb";


            result = new LongestPalindrome().LongestPalindromeString(input);
            Assert.AreEqual(result, expectedResult);
        }


        [TestMethod]
        public void LongestValidParenthesisSuccess()
        {
            string input = "(()";
            var expectedResult = 2;


            var result = new LongestValidParentheses().LongestValidParenthesis(input);

            Assert.AreEqual(result, expectedResult);


            input = ")()())";
            expectedResult = 4;


            result = new LongestValidParentheses().LongestValidParenthesis(input);
            Assert.AreEqual(result, expectedResult);
        }



        [TestMethod]
        public void WordBreakSuccess()
        {
            string input = "leetcode";

            List<string> dict = new List<string>()
            {
                "leet",
                "code"
            };

            var result = new WordBreakSolution().WordBreak(input, dict);
            Assert.IsTrue(result);

            input = "catsandog";

            dict = new List<string>()
            {
                "cats",
                "dog",
                "and"
            };

            result = new WordBreakSolution().WordBreak(input, dict);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void WordBreakBFSSuccess()
        {
            string input = "leetcode";

            List<string> dict = new List<string>()
            {
                "leet",
                "code"
            };

            var result = new WordBreakSolution().WordBreakBFS(input, dict);
            Assert.IsTrue(result);

            input = "catsandog";

            dict = new List<string>()
            {
                "cats",
                "dog",
                "and"
            };

            result = new WordBreakSolution().WordBreakBFS(input, dict);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RangeSum2DSuccess()
        {
            int[][] input = new int[][]
            {
                new int[]{ 3, 0, 1, 4, 2 },
                new int[]{ 5, 6, 3, 2, 1},
                new int[]{ 1, 2, 0, 1, 5 },
                new int[]{ 4, 1, 0, 1, 7 },
                new int[]{ 1, 0, 3, 0, 5 }
            };


            int result;

            result = new NumMatrix(input).SumRegion(2, 1, 4, 3);
            Assert.AreEqual(result, 8);

            result = new NumMatrix(input).SumRegion(1, 1, 2, 2);
            Assert.AreEqual(result, 11);

            result = new NumMatrix(input).SumRegion(1, 2, 2, 4);
            Assert.AreEqual(result, 12);

        }


        [TestMethod]
        public void ContinuousSubarraySumSuccess()
        {
            int k = 6;
            int[] input = new int[] { 23, 2, 4, 6, 7 };

            bool result;

            result = new ContinuousSubarraySum().CheckSubarraySum(input, k);

            Assert.IsTrue(result);

            input = new int[] { 23, 2, 6, 4, 7 };

            result = new ContinuousSubarraySum().CheckSubarraySum(input, k);

            Assert.IsTrue(result);
        }

    }
}
