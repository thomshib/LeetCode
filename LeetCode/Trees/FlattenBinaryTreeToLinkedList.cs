using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/322
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/322/discuss/36977/My-short-post-order-traversal-Java-solution-for-share
    public class FlattenBinaryTreeToLinkedList
    {
        private TreeNode previous = null;
        public void Flatten(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Flatten(root.Right);
            Flatten(root.Left);
            root.Right = previous;
            root.Left = null;
            previous = root;
        }

        public void FlatternIterative(TreeNode root)
        {
            if(root == null)
            {
                return;
            }

            TreeNode previous = null;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while(stack.Count > 0)
            {
                TreeNode current = stack.Pop();
                if(previous != null)
                {
                    previous.Right = current;
                    previous.Left = null;
                }

                previous = current;

                if (current.Right != null) stack.Push(current.Right);
                if (current.Left != null) stack.Push(current.Left);
            }
        }
    }
}
