using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Misc;

namespace LeetCodeTest.Misc
{
    //https://leetcode.com/problems/valid-parentheses/
    //https://www.youtube.com/watch?v=f8Jq8Ibg2Ys

    [TestClass]
    public class ValidParenthesesTests
    {

        [TestMethod]
        public void ValidParenthesesResultsinTrue()
        {
            

            var result = new ValidParentheses().IsValid("()[]{}");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidParenthesesResultsinFalse()
        {


            var result = new ValidParentheses().IsValid("([)]");

            Assert.IsFalse(result);
        }
    }
}
