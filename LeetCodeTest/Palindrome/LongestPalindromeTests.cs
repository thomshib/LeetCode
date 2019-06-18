using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.PlaindromePairs;
namespace LeetCodeTest.Palindrome
{
    [TestClass]
    public  class LongestPalindromeTests
    {
        [TestMethod]
        public void BruteForce_Success()
        {
            var text = "forgeeksskeegfor";
            var expectedResult = "geeksskeeg";
           
            var result = new LongestPalindrome().NaiveSolution(text);

           
            Assert.AreEqual(result,expectedResult);



             text = "bb";
             expectedResult = "bb";

             result = new LongestPalindrome().NaiveSolution(text);


            Assert.AreEqual(result, expectedResult);


            text = "bab";
            expectedResult = "bab";

            result = new LongestPalindrome().LongestPalindromeSolution(text);


            Assert.AreEqual(result, expectedResult);

        }

        [TestMethod]
        public void ManacherSolution_Success()
        {
            var text = "aba";
            var expectedResult = "aba";

            var result = new LongestPalindrome().ManacherSolutions(text);


            Assert.AreEqual(result.Length, expectedResult);
        }
    }
}
