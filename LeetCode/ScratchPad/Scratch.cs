using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.ScratchPad
{
    public class TreeNode
    {
        public int val;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode(int x)
        {
            this.val = x;
        }

    }

   public  class Scratch
    {
        public List<int> InOrderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();

            Stack<TreeNode> stack = new Stack<TreeNode>();

            if(root == null) { return result; }

            while(stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }

                TreeNode node = stack.Pop();
                result.Add(node.val);

                root = root.Right;
            }

            return result;
        }
    }
}
