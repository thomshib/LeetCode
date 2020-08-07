using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/3022/
    public class MaximumPathSum
    {
        int max_sum = int.MinValue;
        public int MaxPathSum(TreeNode root)
        {
            Max_Gain(root);
            return max_sum;
        }

        /*
         * 
         * option-1: pick root and pick left branch or right branch
         * option-2: pick root and pick  +ve left branch and +ve right branch
         *  
            Initiate max_sum as the smallest possible integer and call max_gain(node = root).
            Implement max_gain(node) with a check to continue the old path/to start a new path:
            Base case : if node is null, the max gain is 0.
            Call max_gain recursively for the node children to compute max gain from the left and right subtrees : left_gain = max(max_gain(node.left), 0) and
            right_gain = max(max_gain(node.right), 0).
            Now check to continue the old path or to start a new path. To start a new path would cost price_newpath = node.val + left_gain + right_gain. Update max_sum if it's better to start a new path.
            For the recursion return the max gain the node and one/zero of its subtrees could add to the current path : node.val + max(left_gain, right_gain).
                            
         *           
         * 
         * 
         */
        private int Max_Gain(TreeNode node)
        {
            if (node == null) return 0;

            // max sum on the left and right sub-trees of node
            int left_gain = Math.Max(Max_Gain(node.Left), 0 );
            int right_gain = Math.Max(Max_Gain(node.Right),0);

            // the price to start a new path where `root` is a highest node
            int price_newpath = node.val + left_gain + right_gain;

            // update max_sum if it's better to start a new path
            max_sum = Math.Max(max_sum, price_newpath);

            // for recursion :
            // return the max gain if continue the same path
            return node.val + Math.Max(left_gain,right_gain);
        }
    }
}
