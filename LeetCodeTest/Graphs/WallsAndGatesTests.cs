using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Graphs;
using LeetCodeTest.Utility;

namespace LeetCodeTest.Graphs
{
    [TestClass]
   public  class WallsAndGatesTests
    {
        [TestMethod]
        public void WallsAndGatesResultsinSuccess()
        {

            var matrix = new int[4][]
            {
                new int[4] {int.MaxValue,-1,0,int.MaxValue},
                 new int[4] {int.MaxValue, int.MaxValue, int.MaxValue, -1},
                  new int[4] {int.MaxValue,-1, int.MaxValue, -1},
                   new int[4] {0,-1, int.MaxValue, int.MaxValue}

            };

           var expectedResult = new int[4][]
           {
                new int[4] {3,-1,0,1},
                 new int[4] {2, 2, 1, -1},
                  new int[4] {1,-1,2, -1},
                   new int[4] {0,-1, 3, 4}

           };


            new WallsAndGates().WallsAndGatesSolution(matrix);

            var result = ArrayEquivalence.sequencesEqual(matrix, expectedResult);
            Assert.IsTrue(result);

            


        }
    }
}
