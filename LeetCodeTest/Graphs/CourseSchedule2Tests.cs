using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Graphs;
using LeetCodeTest.Utility;

namespace LeetCodeTest.Graphs
{

    [TestClass]
    public class CourseSchedule2Tests
    {

        [TestMethod]
        public void CourseSchedule2_Success()
        {
            int[][] input = new int[][]
            {
                new int[]{1,0},
                 new int[]{2,0},
                  new int[]{3,1},
                   new int[]{3,2}

            };

            var expectedResult = new int[] { 0, 1, 2, 3 };

            var result = new CourseSchedule2().FindOrder(4, input);

            var isTrue = ArrayEquivalence.sequencesEqual(result, expectedResult);
            Assert.IsTrue(isTrue);

        }
    }
}
