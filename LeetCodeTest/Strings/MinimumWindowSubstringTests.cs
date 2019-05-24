using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeTest.Strings
{

    [TestClass]
    public class MinimumWindowSubstringTests
    {
        [TestMethod]
        public void MinimumWindowSubstring_Success()
        {
            string S = "abcdebdde";
            string T = "bde";

            var expectedResult = "bcde";

            var result = new MinimumWindowSubstring().MinWindow(S, T);

            Assert.AreEqual(result, expectedResult);
        }
    }
}
