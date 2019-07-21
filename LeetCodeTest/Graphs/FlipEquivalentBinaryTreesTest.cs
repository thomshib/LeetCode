using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Graphs;
using LeetCodeTest.Utility;

namespace LeetCodeTest.Graphs
{

    [TestClass]
    public class FlipEquivalentBinaryTreesTests{

        [TestMethod]
        public void Flip_Success(){

            //Tree A
            TreeNode nodeA1 = new TreeNode(1);
            TreeNode nodeA2 = new TreeNode(2);
            TreeNode nodeA3 = new TreeNode(3);
            TreeNode nodeA4 = new TreeNode(4);
            TreeNode nodeA5 = new TreeNode(5);
            TreeNode nodeA6 = new TreeNode(6);
            TreeNode nodeA7 = new TreeNode(7);
            TreeNode nodeA8 = new TreeNode(8);

            nodeA1.left = nodeA2;
            nodeA1.right = nodeA3;

            nodeA2.left = nodeA4;
            nodeA2.right = nodeA5;

            nodeA3.left = nodeA6;

            nodeA5.left = nodeA7;
            nodeA5.right = nodeA8;

            //Tree B
            TreeNode nodeB1 = new TreeNode(1);
            TreeNode nodeB2 = new TreeNode(2);
            TreeNode nodeB3 = new TreeNode(3);
            TreeNode nodeB4 = new TreeNode(4);
            TreeNode nodeB5 = new TreeNode(5);
            TreeNode nodeB6 = new TreeNode(6);
            TreeNode nodeB7 = new TreeNode(7);
            TreeNode nodeB8 = new TreeNode(8);

            nodeB1.left = nodeB3;
            nodeB1.right = nodeB2;

            nodeB2.left = nodeB4;
            nodeB2.right = nodeB5;

            nodeB3.right = nodeB6;

            nodeB5.left = nodeB8;
            nodeB5.right = nodeB7;

            var result = new FlipEquivalentBinaryTrees().FlipEquiv(nodeA1, nodeB1);

            Assert.IsTrue(result);

        }
    }

}