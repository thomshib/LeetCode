using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/291
    //https://www.techiedelight.com/find-diameter-of-a-binary-tree/
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/291/discuss/101219/C-easy-to-understand

    /*
     * The approach is similar to Maxisum sum path problem
     * 
     */
    public class DiameterofBinaryTree
    {
        int maxDiameter = 0;

        public int Height(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = Height(root.Left);
            int rightHeight = Height(root.Right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        //post order traversal
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            //We call the DiameterOfBinaryTree again to check the possibility that the diameter may not pass through the root node
            //Hence, we call the DiameterOfBinaryTree for left sub tree and right sub tree
             DiameterOfBinaryTree(root.Left); //note that maxDiameter gets updated
             maxDiameter = Math.Max(Height(root.Left) + Height(root.Right) , maxDiameter) ;
             DiameterOfBinaryTree(root.Right); //note that maxDiameter gets updated

             return maxDiameter;
        }
    }
}
