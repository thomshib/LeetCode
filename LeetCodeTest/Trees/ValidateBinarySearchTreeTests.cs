using LeetCode.Trees;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace LeetCodeTest.Trees
{

    [TestClass]
    public class ValidateBinarySearchTreeTests
    {


        [TestMethod]
        public void ValidateBSTResultsInSucess()
        {
            var treeNode = new TreeNode(2);
            var treeNode1 = new TreeNode(1);
            var treeNode3 = new TreeNode(3);

            treeNode.Left = treeNode1;
            treeNode.Right = treeNode3;




            var result = new ValidateBinarySearchTree().IsValidBST(treeNode);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateBSTResultsInFailure()
        {
            var treeNode = new TreeNode(5);
            var treeNode1 = new TreeNode(1);
            var treeNode4 = new TreeNode(4);
            var treeNode3 = new TreeNode(3);
            var treeNode6 = new TreeNode(6);

            treeNode.Left = treeNode1;
            treeNode.Right = treeNode4; //this violates the BST property

            treeNode4.Left = treeNode3;
            treeNode4.Right = treeNode6;




            var result = new ValidateBinarySearchTree().IsValidBST(treeNode);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateBSTResultsInFailureForItertiveImpl()
        {
            var treeNode = new TreeNode(5);
            var treeNode1 = new TreeNode(1);
            var treeNode4 = new TreeNode(4);
            var treeNode3 = new TreeNode(3);
            var treeNode6 = new TreeNode(6);

            treeNode.Left = treeNode1;
            treeNode.Right = treeNode4; //this violates the BST property

            treeNode4.Left = treeNode3;
            treeNode4.Right = treeNode6;




            var result = new ValidateBinarySearchTree().IsValidBSTIterative(treeNode);

            Assert.IsFalse(result);
        }
    }

}
