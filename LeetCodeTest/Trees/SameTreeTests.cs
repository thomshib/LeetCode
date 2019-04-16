using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Trees;

namespace LeetCodeTest.Trees
{
    [TestClass]
    public class SameTreeTests
    {

        [TestMethod]
        public void SimilarTreeResultsInSucess()
        {
            var treeNode1 = new TreeNode(1);
            var treeNode2 = new TreeNode(2);
            var treeNode3 = new TreeNode(3);

            treeNode1.Left = treeNode2;
            treeNode1.Right = treeNode3;



           
            var result = new SameTree().IsSameTree(treeNode1, treeNode1);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void DisimilarTreeResultsInSuccess()
        {
            var treeNode1A = new TreeNode(1);
            var treeNode2A = new TreeNode(2);
            treeNode1A.Left = treeNode2A;

            var treeNode1B = new TreeNode(1);
            var treeNode2B = new TreeNode(2);
            treeNode1B.Right = treeNode2B;



            var result = new SameTree().IsSameTree(treeNode1A, treeNode1B);

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void SimilarTreeResultsInSucessForIterativeImplementation()
        {
            var treeNode1 = new TreeNode(1);
            var treeNode2 = new TreeNode(2);
            var treeNode3 = new TreeNode(3);

            treeNode1.Left = treeNode2;
            treeNode1.Right = treeNode3;




            var result = new SameTree().IsSameTreeIterative(treeNode1, treeNode1);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void DisimilarTreeResultsInSuccessForIterativeImplementation()
        {
            var treeNode1A = new TreeNode(1);
            var treeNode2A = new TreeNode(2);
            treeNode1A.Left = treeNode2A;

            var treeNode1B = new TreeNode(1);
            var treeNode2B = new TreeNode(2);
            treeNode1B.Right = treeNode2B;



            var result = new SameTree().IsSameTreeIterative(treeNode1A, treeNode1B);

            Assert.IsFalse(result);
        }
    }
}
