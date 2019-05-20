using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.BackTracking;

namespace LeetCodeTest.BackTracking
{
    [TestClass]
    public class RegularExpressionMatchingTests
    {

        [TestMethod]
        public void IsMatchResultsInSuccess()
        {
            string text = "aab";
            string pattern = "c*a*b";

            var result = new RegularExpressionMatching().IsMatch(text, pattern);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void IsMatchResultsInFailure()
        {
            string text = "mississippi";
            string pattern = "mis*is*p*.";

            var result = new RegularExpressionMatching().IsMatch(text, pattern);

            Assert.IsFalse(result);
        }
    }
}
