using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Graphs;
using LeetCodeTest.Utility;



namespace LeetCodeTest.Graphs
{
    [TestClass]
    public class ZigzagTraversalTest{

        [TestMethod]
        public void TravesalSuccess(){

                TreeNode node3 = new TreeNode(3);
                 TreeNode node9 = new TreeNode(9);
                  TreeNode node20 = new TreeNode(20);
                   TreeNode node15 = new TreeNode(15);
                    TreeNode node7 = new TreeNode(7);
        
                node3.left = node9;
                node3.right = node20;

                node20.left = node15;
                node20.right = node7;

        

        List<IList<int>> expectedResult = new List<IList<int>>(){
            new List<int>(){3},
            new List<int>(){20,9},
            new List<int>(){15,7}

        };


        var result = new ZigzagTraversal().ZigzagLevelOrder(node3);

        var areEqual = CollectionsAreEqual.AreEqualListOfLists(result,expectedResult);

        Assert.IsTrue(areEqual);

    }
}
}
