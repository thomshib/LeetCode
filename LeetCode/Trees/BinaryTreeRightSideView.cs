using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{

    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/3023
    public class BinaryTreeRightSideView
    {

        //At each level choose one of the left or righ nodes
        //depth and size of the list are equal at each level
        public IList<int> RightSideView(TreeNode root)
        {

            List<int> result = new List<int>();

            if (root == null)
            {
                return result;
            }

            RightSideView(root, result, 0);

            return result;
        }

        private void RightSideView(TreeNode node, List<int> result, int depth)
        {
            if (node == null) return;

            if(result.Count == depth)
            {
                result.Add(node.val);
            }

            RightSideView(node.Right, result, depth + 1);
            RightSideView(node.Left, result, depth + 1);

        }
    }
}
