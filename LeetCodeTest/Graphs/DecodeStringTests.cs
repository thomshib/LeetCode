using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Graphs;

namespace LeetCodeTest.Graphs
{
    [TestClass]
    public class DecodeStringTests
    {
        [TestMethod]
        public void DecodeString_Success()
        {
            string input = "3[a]2[bc]";
            string expectedResult = "aaabcbc";

            var result = new DecodeStringSolution().DecodeString(input);

            Assert.AreEqual(result, expectedResult);


             input = "3[a2[c]]";
             expectedResult = "accaccacc";

             result = new DecodeStringSolution().DecodeString(input);

            Assert.AreEqual(result, expectedResult);

            input = "2[abc]3[cd]ef";
            expectedResult = "abcabccdcdcdef";

            result = new DecodeStringSolution().DecodeString(input);

            Assert.AreEqual(result, expectedResult);



        }
    }
}
