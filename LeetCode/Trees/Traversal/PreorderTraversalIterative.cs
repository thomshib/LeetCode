using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees.Traversal
{
    public class PreorderTraversalIterative
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {

            List<int> result = new List<int>();

            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {

                var node = stack.Pop();
                result.Add(node.val);

                var currentNode = node;


                if (node.Right != null)
                {
                    
                        stack.Push(node.Right);
                    
                }

                if (node.Left != null)
                {
                    
                        stack.Push(node.Left);
                    
                }
               

                 
               
            }

            return result;
        }
    }
}
