using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    //https://leetcode.com/problems/path-sum/
    //https://github.com/mission-peace/interview/blob/master/src/com/interview/tree/RootToLeafToSum.java
    public class RootToLeafSum
    {

        public bool FindSum(TreeNode root, int sum, List<TreeNode> path)
        {

            if (root == null) return false;

            if (root.Left == null && root.Right == null) //leaf node
            {
                if (root.val == sum)
                {
                    path.Add(root);
                    return true;
                }
                else
                {
                    return false;
                }
            }


            if( FindSum(root.Left,sum-root.val, path) || FindSum(root.Right, sum - root.val, path) ){
                return true;
            }

            return false;
        }
    }
}
