
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Graphs;

namespace LeetCodeTest.Graphs
{
[TestClass]
public class MostStonesRemovedTests{


    [TestMethod]
    public void StonesRemoved_Success(){
        int[][] input = new int[][]{
            new int[]{0,0},
             new int[]{0,1},
              new int[]{1,0},
               new int[]{1,2},
                new int[]{2,1},
                 new int[]{2,2}
        };

        var expectedResult = 5;

        var result = new MostStonesRemoved().RemoveStones(input);
        Assert.AreEqual(result,expectedResult);

    }


   
    [TestMethod]
    public void StonesRemovedUnionFind_Success(){
        int[][] input = new int[][]{
            new int[]{0,0},
             new int[]{0,1},
              new int[]{1,0},
               new int[]{1,2},
                new int[]{2,1},
                 new int[]{2,2}
        };

        var expectedResult = 5;

        var result = new MostStonesRemoved().RemoveStonesUnionFind(input);
        Assert.AreEqual(result,expectedResult);
        
    } 
}

}