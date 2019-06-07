using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees.Traversal
{
    public class InOrderTraversalIterative
    {

        /*
         * process the left tree of the root
         * pop the stack and process the node
         * process the right tree of the poped node
         * 
         * 
         * 
         */
        public IList<int> InOrderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            

            while (root != null || stack.Count > 0)
            {
                while(root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }

                root = stack.Pop();
                result.Add(root.val);

                root = root.Right;
              
               
                
            }

            return result;
        }
    }
}
