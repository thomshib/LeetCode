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

            new ConstructLinkedListFromBinaryTree().ConstructLinkedList(treeNode1, null);

        }
    }
}
