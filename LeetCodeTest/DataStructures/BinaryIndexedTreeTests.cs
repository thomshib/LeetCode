using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.DataStructures;

namespace LeetCodeTest.DataStructures
{

[TestClass]
 public class BinaryIndexedTreeTests{

      [TestMethod]
    public void  BinaryIndexedTreeSuccess (){
     
        int[] array = new int[]{1,3,5};

        int n = array.Length;

        var binaryTree = new BinaryIndexedTree(array);

        var result = binaryTree.RangeQuery(0,n-1);
        Assert.AreEqual(result,9);

    }
 }

}