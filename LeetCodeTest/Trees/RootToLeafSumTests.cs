using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Trees;

namespace LeetCodeTest.Trees
{
    [TestClass]
    public class RootToLeafSumTests
    {
        [TestMethod]
        public void BinaryTreePathResultsInSucessForRecursiveImplementation()
        {
            var treeNode10 = new TreeNode(10);
            var treeNode16 = new TreeNode(19);
            var treeNode3 = new TreeNode(3);
            var treeNode5 = new TreeNode(5);
            var treeNode6 = new TreeNode(6);
            var treeNode11 = new TreeNode(11);

            treeNode10.Left = treeNode16;
            treeNode10.Right = treeNode5;

            treeNode16.Right = treeNode3;

            treeNode5.Left = treeNode6;
            treeNode5.Right = treeNode11;

            var expectedResult = new List<string>()
            {
                "1->2->5",
                "1->3"
            };

            var path = new List<TreeNode>();

            var result = new RootToLeafSum().FindSum(treeNode10,26,path);

            Assert.IsTrue(result);
        }

    }
}
