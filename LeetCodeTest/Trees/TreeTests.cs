using LeetCode.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Trees.Traversal;

namespace LeetCodeTest.Trees
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void MaximumPathSumSuccess()
        {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);

            var result = new MaximumPathSum().MaxPathSum(root);

            Assert.AreEqual(result, 6);


            root = new TreeNode(-3);
            result = new MaximumPathSum().MaxPathSum(root);
            Assert.AreEqual(result, -3);


        }

        [TestMethod]
        public void RootToLeafSumAllSuccess()
        {
            TreeNode root = new TreeNode(6);
            var node4 = root.Left = new TreeNode(4);
            var node8 = root.Right = new TreeNode(8);

            node4.Left = new TreeNode(3);
            node4.Right = new TreeNode(5);

            node8.Left = new TreeNode(7);

            var expectedResult = new List<int> { 13, 15, 21 };

            var result = new RootToLeafSumAll().CalulateSum(root);

            CollectionAssert.AreEqual(result, expectedResult);

        }

        [TestMethod]
        public void MaximumDepthSuccess()
        {
            TreeNode root = new TreeNode(3);

            var node9 = root.Left = new TreeNode(9);
            var node20 = root.Right = new TreeNode(20);

            node20.Left = new TreeNode(15);
            node20.Right = new TreeNode(7);


            var result = new MaximumDepth().MaxDepth(root);

            Assert.AreEqual(result,3);

        }


        [TestMethod]
        public void ConstructBinaryTreeFromInorderPostorderTraversalSuccess()
        {

            var postorder = new int[] { 9, 15, 7, 20, 3 };
            var inorder = new int[] { 9, 3, 15, 20, 7 };

            var result = new ConstructBinaryTreeFromInorderPostorderTraversal().BuildTree(inorder,postorder);

            var inOrderTraversalResult = new InOrderTraversalIterative().InOrderTraversal(result);

            var areEqual = CollectionsAreEqual.AreEqual<int>(inorder, inOrderTraversalResult);
            Assert.IsNotNull(result);
            Assert.IsTrue(areEqual);


            

        }

    }
}