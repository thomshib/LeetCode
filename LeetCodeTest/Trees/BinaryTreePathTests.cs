using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Trees;

namespace LeetCodeTest.Trees
{
    [TestClass]
    public class BinaryTreePathTests
    {

        [TestMethod]
        public void BinaryTreePathResultsInSucessForRecursiveImplementation()
        {
            var treeNode1 = new TreeNode(1);
            var treeNode2 = new TreeNode(2);
            var treeNode3 = new TreeNode(3);
            var treeNode5 = new TreeNode(5);

            treeNode1.Left = treeNode2;
            treeNode1.Right = treeNode3;

            treeNode2.Right = treeNode5;

            var expectedResult = new List<string>()
            {
                "1->2->5",
                "1->3"
            };           


            var result = new BinaryTreePaths().BinaryTreePathsRecursive(treeNode1);

            var areEqual = CollectionsAreEqual.AreEqual<string>(result, expectedResult);
            Assert.IsTrue(areEqual);
        }


        [TestMethod]
        public void BinaryTreePathResultsInSucessForIterativeImplementation()
        {
            var treeNode1 = new TreeNode(1);
            var treeNode2 = new TreeNode(2);
            var treeNode3 = new TreeNode(3);
            var treeNode5 = new TreeNode(5);

            treeNode1.Left = treeNode2;
            treeNode1.Right = treeNode3;

            treeNode2.Right = treeNode5;

            var expectedResult = new List<string>()
            {
                "1->2->5",
                "1->3"
            };


            var result = new BinaryTreePaths().BinaryTreePathsIterative(treeNode1);

            var areEqual = CollectionsAreEqual.AreEqual<string>(result, expectedResult);
            Assert.IsTrue(areEqual);
        }
    }
}
