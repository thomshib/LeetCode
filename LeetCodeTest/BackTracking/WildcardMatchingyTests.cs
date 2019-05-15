using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.BackTracking;

namespace LeetCodeTest.BackTracking
{
    [TestClass]
    public class WildcardMatchingTests
    {

        [TestMethod]
        public void WildCardResultsInSuccess()
        {
            string inputString = "adceb";
            string inputPattern = "*a*b";

            var result = new WildcardMatching().IsMatch(inputString, inputPattern);

            Assert.IsTrue(result);

        }


        [TestMethod]
        public void WildCardResultsInFailure()
        {
            string inputString = "acdcb";
            string inputPattern = "a*c?b";

            var result = new WildcardMatching().IsMatch(inputString, inputPattern);

            Assert.IsFalse(result);

        }
    }
}
