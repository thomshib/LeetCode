using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Recursions;

namespace LeetCodeTest.Recursions
{
    [TestClass]
    public class LetterCombinationsTests
    {

       [TestMethod]
        public void LetterCombinationResultsInSuccess()
        {
            var expectedResult = new List<string>
            {
                "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"
            };

            var result = new LetterCombinations().LetterCombinationsSolution("23");

            var areEqual = CollectionsAreEqual.AreEqual<string>(result, expectedResult);

            Assert.IsTrue(areEqual);
        }
    }
}
