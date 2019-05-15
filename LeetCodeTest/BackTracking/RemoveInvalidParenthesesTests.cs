using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.BackTracking;

namespace LeetCodeTest.BackTracking
{
    [TestClass]
    public class RemoveInvalidParenthesesTests
    {

        [TestMethod]
        public void RemoveParenThesisResultsInSuccess()
        {
            string input = "()())()";

            List<string> expectedResult = new List<string>()
            {
                 "(())()",
                "()()()",               
            };

            var result = new RemoveInvalidParenthesesSolution().RemoveInvalidParentheses(input);

            var areEqual = CollectionsAreEqual.AreEqual(result, expectedResult);

            Assert.IsTrue(areEqual);
        }
    }
}
