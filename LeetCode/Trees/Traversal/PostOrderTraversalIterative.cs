using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees.Traversal
{
    public class PostOrderTraversalIterative
    {
        public IList<int> PostOrderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode currentNode = root;
            TreeNode previousRightNode = null;

            while(currentNode != null || stack.Count > 0)
            {
                while(currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }

                currentNode = stack.Peek();

                //check whether to process the right node or not
                if(currentNode.Right != null && currentNode.Right != previousRightNode)
                {
                    //there exists a right node and it has not been processed
                    currentNode = currentNode.Right;
                }
                else //process the current node
                {
                    currentNode = stack.Pop();
                    result.Add(currentNode.val);
                    previousRightNode = currentNode;
                    currentNode = null;
                }
            }

            return result;
        }
    }
}
