using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.WordBreak;
namespace LeetCodeTest.WordBreak
{
    [TestClass]
    public class WordBreakTests
    {

        [TestMethod]
        public void NaiveSolutionShouldReturnTrue()
        {
            var text = "leetcode";
            var dict = new List<string>() { "leet", "code" };
            

            var result = new WordBreakSolution().NaiveSolution(text,dict);


            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DynamicSolutionShouldReturnTrue()
        {
            var text = "leetcode";
            var dict = new List<string>() { "leet", "code" };


            var result = new WordBreakSolution().DynamicProgrammingSolution(text, dict);


            Assert.IsTrue(result);
        }
    }
}
