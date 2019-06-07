using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    public class SymmetricTree
    {
        //https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/536/

        public bool IsSymmetricRecursive(TreeNode root)
        {
            if(root == null)
            {
                return false;
            }

            return Helper(root.Left, root.Right);

        }

        private bool Helper(TreeNode left, TreeNode right)
        {
            if(left == null || right == null)
            {
                return left == right;
            }

            if(left.val != right.val)
            {
                return false;
            }

            return Helper(left.Left, right.Right) && Helper(left.Right, right.Left);
        }


        public bool IsSymmetricIterative(TreeNode root)
        {
            if (root == null)
            {
                return false;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root.Left);
            stack.Push(root.Right);

            while(stack.Count > 0)
            {
                var n1 = stack.Pop();
                var n2 = stack.Pop();

                if (n1 == null && n2 == null) continue;

                if (n1 == null || n2 == null || n1.val != n2.val) return false;
                stack.Push(n1.Left);
                stack.Push(n2.Right);

                stack.Push(n1.Right);
                stack.Push(n2.Left);

            }

            return true;

        }
    }
}
