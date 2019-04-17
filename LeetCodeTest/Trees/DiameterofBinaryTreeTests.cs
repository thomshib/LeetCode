using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Trees;

namespace LeetCodeTest.Trees
{
    [TestClass]
    public class DiameterofBinaryTreeTests
    {
        [TestMethod]
        public void DiameterOfBinary_Success()
        {
            var treeNode1 = new TreeNode(1);
            var treeNode2 = new TreeNode(2);
            var treeNode3 = new TreeNode(3);
            var treeNode4 = new TreeNode(4);
            var treeNode5 = new TreeNode(5);
     

            treeNode1.Left = treeNode2;
            treeNode1.Right = treeNode3;

            

            treeNode2.Left = treeNode4;
            treeNode2.Right = treeNode5;

            var expectedResult = 3;

            

            var result = new DiameterofBinaryTree().DiameterOfBinaryTree(treeNode1);

            Assert.AreEqual(result,expectedResult);
        }
    }
}
