using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    public class InOrderTraversalSolution
    {
        public List<int> InOrderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
            {
                return result;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();

            while(stack.Count > 0 || root != null)
            {
                //push all the left nodes
                while (root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }

                //pop the left node
                root = stack.Pop();
                result.Add(root.val);

                //add the right node
                root = root.Right;
                
            }
            return result;
        }
    }
}
