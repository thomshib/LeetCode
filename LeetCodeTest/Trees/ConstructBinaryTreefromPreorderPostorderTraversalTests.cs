using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Trees;

namespace LeetCodeTest.Trees
{
    [TestClass]
    public class ConstructBinaryTreefromPreorderPostorderTraversalTests
    {
        /***
         * pre[] leftmost element is root say 1
         * pre[] next element of 1 is left, say 2
         * 
         * post[] - all elements left of 2, is part of left subtree
         * post[] = all element right of 2, is part of right subtree
         * 
         * 
         */

        [TestMethod]
        public void PreOrderPostOrderTraversal_Success()
        {
            var preorder = new int[] { 1, 2, 4, 8, 9, 5, 3, 6, 7 };
            var postorder = new int[] { 8, 9, 4, 5, 2, 6, 7, 3, 1 };

            var result = new ConstructBinaryTreefromPreorderPostorderTraversal().BuildTree(preorder, postorder);

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
                Helper(root.Left, result);
                Helper(root.Right, result);

            }
        }

    }
}
