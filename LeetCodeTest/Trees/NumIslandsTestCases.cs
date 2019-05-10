using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Trees;

namespace LeetCodeTest.Trees
{
    [TestClass]
    public class NumIslandsTestCases
    {
        [TestMethod]
        public void NumsIslandResultsInSuccess()
        {
            char[][] island = new char[][] {
                new char[]{'1','1','0','0','0'},
                 new char[]{'1','1','0','0','0'},
                  new char[]{'0','0','1','0','0'},
                   new char[]{'0','0','0','1','1'}

            };


            var expectedResult = 3;

            var result = new NumberOfIslands().NumIslands(island);

            Assert.AreEqual(result, expectedResult);

        }
    }
}
