using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Trees;

namespace LeetCodeTest.Trees
{
    [TestClass]
    public class ConstructBinaryTreefromPreorderInorderTraversalTests
    {

        [TestMethod]
        public void PreOrderInOrderTraversal_Success()
        {
            var preorder = new int[] { 3, 9, 20, 15, 7 };
            var inorder = new int[] { 9, 3, 15, 20, 7 };

            var result = new ConstructBinaryTreefromPreorderInorderTraversal().BuildTree(preorder, inorder);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void PreOrderInOrderTraversalRecursive_Success()
        {
            var preorder = new int[] { 3, 9, 20, 15, 7 };
            var inorder = new int[] { 9, 3, 15, 20, 7 };

            var result = new ConstructBinaryTreefromPreorderInorderTraversal().BuildTreeRecursive(preorder, inorder);

            var preOrderTraversalResult = PreOrderTraversal(result);

            var areEqual = CollectionsAreEqual.AreEqual<int>(preorder, preOrderTraversalResult); 
            Assert.IsNotNull(result);
            Assert.IsTrue(areEqual);
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
                Helper(root.Left,result);
                Helper(root.Right, result);

            }
        }
    }
}
