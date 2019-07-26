using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.DataStructures;

namespace LeetCodeTest.DataStructures
{

[TestClass]

public class SegmentTreeTests{

    [TestMethod]
    public void SegmentTreeSuccess (){

        int[] array = new int[]{1,3,5};

        int n = array.Length;

        var segTree = new SegmentTree(array);

        var result = segTree.QuerySegmentTree(0,0,n-1, 0, n-1);
        Assert.AreEqual(result,9);

    }

    

}

}