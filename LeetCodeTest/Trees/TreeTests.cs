using LeetCode.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
