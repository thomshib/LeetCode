using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Others;

namespace LeetCodeTest.Others
{

 [TestClass]
    public  class MaxPointsOnLineTests
    {
        [TestMethod]
        public void MaxPointsOnLineTests_Success()
        {
            var input = new int[][]{
                new int[]{1,1},
                new int[]{2,2},
                new int[]{3,3}
            };

            var result = new MaxPointsOnLine().MaxPoints(input);

            Assert.AreEqual(result,3);



            input = new int[][]{
                new int[]{1,1},
                new int[]{3,2},
                new int[]{5,3},
                 new int[]{4,1},
                  new int[]{2,3},
                   new int[]{1,4}
            };

            result = new MaxPointsOnLine().MaxPoints(input);

            Assert.AreEqual(result,4);
        }

    }
}