using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Trees;


namespace LeetCodeTest.Trees
{
    [TestClass]
    public class BinaryTreeVerticalOrderTraversalTests
    {
        [TestMethod]
        public void VerticalOrderTraversalResultsInSuccess()
        {
            
            var treeNode3 = new TreeNode(3);
            var treeNode9 = new TreeNode(9);
            var treeNode20 = new TreeNode(20);
            var treeNode15 = new TreeNode(15);
            var treeNode7 = new TreeNode(7);

            treeNode3.Left = treeNode9;
            treeNode3.Right = treeNode20;


            treeNode20.Left = treeNode15;
            treeNode20.Right = treeNode7;

            var expectedResult = new List<List<int>>()
            {
                new List<int>{ 9},
                new List<int>{ 3,15},
                new List<int>{ 20},
                new List<int>{ 7}
            };


            var result = new BinaryTreeVerticalOrderTraversal().VerticalOrder(treeNode3);

            var areEqual = CollectionsAreEqual.AreEqualListOfLists(result, expectedResult);

            Assert.IsTrue(areEqual);
        }

    }
}
