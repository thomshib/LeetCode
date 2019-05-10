using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Trees;

namespace LeetCodeTest.Trees
{
    [TestClass]
    public class ConstructLinkedListFromBinaryTreeTests
    {

        [TestMethod]
        public void ContructResultsInSuccess()
        {
            var treeNode1 = new TreeNode(1);
            var treeNode2 = new TreeNode(2);
            var treeNode3 = new TreeNode(3);
            var treeNode4 = new TreeNode(4);
            var treeNode5 = new TreeNode(5);
            var treeNode6 = new TreeNode(6);
            var treeNode7 = new TreeNode(7);

            treeNode1.Left = treeNode2;
            treeNode1.Right = treeNode3;

            treeNode2.Left = treeNode4;
            treeNode2.Right = treeNode5;

            treeNode3.Left = treeNode6;
            treeNode3.Right = treeNode7;

            // null,4,2,5,1,6,3,7, null

            var expectedResult = new int?[] {  4, 2, 5, 1, 6, 3, 7};

            new ConstructLinkedListFromBinaryTree().ConstructLinkedList(treeNode1, null);

            var result = LinkedListTraversal(treeNode4);

            Assert.AreEqual(result, expectedResult);

        }

        [TestMethod]
        public void ConstructLinkedListIterative_Success()
        {
            var treeNode1 = new TreeNode(1);
            var treeNode2 = new TreeNode(2);
            var treeNode3 = new TreeNode(3);
            var treeNode4 = new TreeNode(4);
            var treeNode5 = new TreeNode(5);
            var treeNode6 = new TreeNode(6);
            var treeNode7 = new TreeNode(7);

            treeNode1.Left = treeNode2;
            treeNode1.Right = treeNode3;

            treeNode2.Left = treeNode4;
            treeNode2.Right = treeNode5;

            treeNode3.Left = treeNode6;
            treeNode3.Right = treeNode7;

            var expectedResult = new int?[] { 4, 2, 5, 1, 6, 3, 7 };

            var result = new ConstructLinkedListFromBinaryTree().ConstructLinkedListIterative(treeNode1);

            var output = LinkedListTraversal(result);

            Assert.AreEqual(result, expectedResult);
        }

        private int[] LinkedListTraversal(TreeNode treeNode)
        {
            List<int> result = new List<int>();

            while(treeNode != null)
            {
                result.Add(treeNode.val);
                treeNode = treeNode.Right;

            }

            return result.ToArray();

        }

        public int[] PreOrderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();

            Helper(root, result);

            return result.ToArray();
        }

        private void Helper(TreeNode root, List<int> result)
        {
            if (root != null)
            {
                result.Add(root.val);
                Helper(root.Left, result);
                Helper(root.Right, result);

            }
        }
    }
}
