using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    public class ValidateBinarySearchTree
    {

        //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/266/discuss/262041/Iterative-and-Recursive-Inorder

        public bool IsValidBST(TreeNode root)
        {


            return IsValidBST(root, null, null);


        }

        public bool IsValidBST(TreeNode root, TreeNode min, TreeNode max)
        {


            if (root == null)
            {
                return true;
            }

            if (min != null && root.val <= min.val) return false;
            if (max != null && root.val >= max.val) return false;

            return IsValidBST(root.Left, min, root) && IsValidBST(root.Right, root, max);



        }


        public bool IsValidBSTIterative(TreeNode root)
        {

            TreeNode prevNode = null;
            TreeNode currNode = null;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            PushUntilBottomLeft(root, stack);

            while(stack.Count > 0){

                currNode = stack.Pop();

                if (prevNode != null && prevNode.val >= currNode.val) return false;

                prevNode = currNode;

                if (currNode.Right != null)
                {
                    stack.Push(currNode.Right);
                    PushUntilBottomLeft(currNode.Right, stack);
                }
            }

            return true;
            


        }

        private void PushUntilBottomLeft(TreeNode node, Stack<TreeNode> stack)
        {
            while(node.Left != null)
            {
                stack.Push(node.Left);
                node = node.Left;
            }
            
        }
    }
}
