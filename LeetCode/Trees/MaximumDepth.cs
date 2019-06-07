using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{

    //https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/535/
    public class MaximumDepth
    {
        int result = 0;
        public int MaxDepth(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            Helper(root, 1);
            return result;
        }

        private void Helper(TreeNode node, int depth)
        {
            if (node == null)
            {
                return;
            }
            if(node.Left == null && node.Right == null) //leaf node
            {
                result = Math.Max(result, depth);
            }

            Helper(node.Left, depth + 1);
            Helper(node.Right, depth + 1);

        }
    }
}
