using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Arrays;
using LeetCodeTest.Utility;

namespace LeetCodeTest.Arrays
{
    [TestClass]
    public class ExpressiveWordsTest
    {
        [TestMethod]
        public void ExpressiveWords_Success(){

            var expectedResult = 1;
            var input = "heeellooo";
            string[] words = new string[]{"hello", "hi", "helo"};

            var result = new ExpressiveWords().ExpressiveWordsSolution(input,words);
            Assert.AreEqual(result,expectedResult);

        }
    }
}