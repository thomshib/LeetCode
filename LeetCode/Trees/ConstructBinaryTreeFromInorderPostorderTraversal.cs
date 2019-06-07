using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{

    //https://leetcode.com/explore/learn/card/data-structure-tree/133/conclusion/942/
    //https://www.youtube.com/watch?v=k2dvEJoHVEM
    //https://leetcode.com/explore/learn/card/data-structure-tree/133/conclusion/942/discuss/34782/My-recursive-Java-code-with-O(n)-time-and-O(n)-space
    public class ConstructBinaryTreeFromInorderPostorderTraversal
    {
        /*
         * The the basic idea is to take the last element in postorder array as the root, 
         * find the position of the root in the inorder array; then locate the range for left sub-tree and right sub-tree 
         * and do recursion. 
         * Use a HashMap to record the index of root in the inorder array.
         * 
         * Step 1 : Mark the last element in postorder as the root
         * Step 2 : Mark the index of the root in inorder
         * Step 3 : Root element will divide the inorder result into left subtree and right subtree
         */

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder == null || inorder.Length == 0 || postorder == null || postorder.Length == 0)
            {
                return null;
            }

            return Helper(postorder, postorder.Length - 1, inorder, 0, inorder.Length - 1);

        }

        private TreeNode Helper(int[] postorder, int rootIndex, int[] inorder, int start, int end)
        {
            if(start > end || rootIndex < 0)
            {
                return null;
            }

            TreeNode root = new TreeNode(postorder[rootIndex]);
            //find the index of the root node in inorder array
            int rootInorderIndex = -1;
            for(int i = start; i <= end; i++)
            {
                if(inorder[i] == root.val)
                {
                    rootInorderIndex = i;
                    break;
                }
            }

            //nodes to the right of the rootInorderIndex in inorder array forms the right tree
            root.Right = Helper(postorder, rootIndex - 1, inorder, rootInorderIndex + 1, end);

            //nodes to the left of the rootInorderIndex in inorder array forms the left tree
            //rootIndex = end - rootInorderIndex + 1

            int rightTreeLength = end - rootInorderIndex;
            root.Left = Helper(postorder, rootIndex - rightTreeLength + 1, inorder, start, rootInorderIndex - 1);

            return root;
        }
    }
}
