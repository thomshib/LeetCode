using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    //https://leetcode.com/problems/sum-of-left-leaves/
    //https://www.youtube.com/watch?v=_gnyuO2uquA
    public class SumofLeftLeaves
    {
        public int SumOfLeftLeaves(TreeNode root)
        {

            if (root == null)
            {
                return 0;
            }

              if (root.Left != null && root.Left.Left == null && root.Left.Right == null) //root.Left is a leaf node
                {
                    return root.Left.val + SumOfLeftLeaves(root.Right);
                }
                else
                {
                return SumOfLeftLeaves(root.Right) + SumOfLeftLeaves(root.Left);
                }
          
        }
    }
}
