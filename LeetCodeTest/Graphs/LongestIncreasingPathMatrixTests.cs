using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Graphs;
namespace LeetCodeTest.Graphs
{

    [TestClass]
    public class LongestIncreasingPathMatrixTests
    {

        [TestMethod]
        public void LongestPath_Success()
        {
            int[][] matrix = new int[][]
            {
                new int[]{9,9,4},
                new int[]{6,6,8},
                new int[]{2,1,1}
            };

            var expectedResult = 4;

            var result = new LongestIncreasingPathMatrix().LongestIncreasingPath(matrix);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
