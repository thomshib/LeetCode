using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Trees.Traversal;
using LeetCode.Trees;

namespace LeetCodeTest.Trees.Traversal
{
    [TestClass]
    public class TraversalTests
    {
        [TestMethod]
        public void PreorderTraversalIterativeSuccess()
        {
            TreeNode root = new TreeNode(1);

            var node4 = root.Left = new TreeNode(4);
            var node3 = root.Right = new TreeNode(3);

            node4.Left = new TreeNode(2);
            node4.Right = new TreeNode(5);

            var result = (List<int>) new PreorderTraversalIterative().PreorderTraversal(root);

            CollectionAssert.AreEqual(result, new List<int>() { 1, 4, 2, 5,3 });

        }


        [TestMethod]
        public void PreorderTraversalRecursiveSuccess()
        {
            TreeNode root = new TreeNode(1);

            var node4 = root.Left = new TreeNode(4);
            var node3 = root.Right = new TreeNode(3);

            node4.Left = new TreeNode(2);
            node4.Right = new TreeNode(5);

            var result = (List<int>)new PreorderTraversalRecursive().PreorderTraversal(root);

            CollectionAssert.AreEqual(result, new List<int>() { 1, 4, 2, 5, 3 });

        }


        [TestMethod]
        public void InorderTraversalIterativeSuccess()
        {
            TreeNode root = new TreeNode(1);

            var node4 = root.Left = new TreeNode(4);
            var node3 = root.Right = new TreeNode(3);

            node4.Left = new TreeNode(2);
            node4.Right = new TreeNode(5);

            var result = (List<int>)new InOrderTraversalIterative().InOrderTraversal(root);

            CollectionAssert.AreEqual(result, new List<int>() {2,4,5,1,3 });

        }

        [TestMethod]
        public void InorderTraversalRecursiveSuccess()
        {
            TreeNode root = new TreeNode(1);

            var node4 = root.Left = new TreeNode(4);
            var node3 = root.Right = new TreeNode(3);

            node4.Left = new TreeNode(2);
            node4.Right = new TreeNode(5);

            var result = (List<int>)new InOrderTraversalIterative().InOrderTraversal(root);

            CollectionAssert.AreEqual(result, new List<int>() { 2, 4, 5, 1, 3 });

        }

        [TestMethod]
        public void PostorderTraversalIterativeSuccess()
        {
            TreeNode root = new TreeNode(1);

            var node2 = root.Left = new TreeNode(2);
            var node3 = root.Right = new TreeNode(3);

            node2.Left = new TreeNode(4);
            node2.Right = new TreeNode(5);

            

            var result = (List<int>)new PostOrderTraversalIterative().PostOrderTraversal(root);

            CollectionAssert.AreEqual(result, new List<int>() { 4, 5,2, 3,1 });

        }


        [TestMethod]
        public void BFSTraversalIterativeSuccess()
        {
            TreeNode root = new TreeNode(3);

            var node9 = root.Left = new TreeNode(9);
            var node20 = root.Right = new TreeNode(20);

            node20.Left = new TreeNode(15);
            node20.Right = new TreeNode(7);

            var expectedResult = new List<List<int>>()
            {
                new List<int>(){3},
                 new List<int>(){9,20},
                  new List<int>(){15,7},

            };


            var result = (List<List<int>>) new BFSTraversal().LevelOrder(root);

            var areEqual = CollectionsAreEqual.AreEqualListOfLists(result, expectedResult);

        }
    }
}
