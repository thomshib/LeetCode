using LeetCode.Trees;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Trees
{
    public class ConstructBinaryTreefromPreorderPostorderTraversal
    {
        /***
         * pre[] leftmost element is root say 1
         * pre[] next element of 1 is left, say 2
         * 
         * post[] - all elements left of 2, is part of left subtree
         * post[] = all element right of 2, is part of right subtree
         * 
         * 
         */

        public TreeNode BuildTree(int[] preorder, int[] postorder)
        {
            if (postorder == null || preorder == null)
            {
                return null;
            }

            

            return helper(0, 0, postorder.Length - 1, preorder, postorder);
           
            

        }

        private TreeNode helper(int startPreOrder, int startPostOrder, int endPostOrder, int[] preorder, int[] postorder)
        {
            if (startPreOrder > preorder.Length - 1 || startPostOrder > endPostOrder)
            {
                return null;
            }

            TreeNode root = new TreeNode(preorder[startPreOrder]);

            int currentNodeIndex = 0;
            int leftNodeIndex = startPreOrder++; //next element of root in pre
            if (leftNodeIndex <= preorder.Length - 1)
            {



                //find the next element of pre[] in post[]
                for (int i = startPostOrder; i <= endPostOrder; i++)
                {
                    if (postorder[i] == preorder[leftNodeIndex])
                    {
                        currentNodeIndex = i;
                    }
                }


                root.Left = helper(startPreOrder + 1, startPostOrder, currentNodeIndex - 1, preorder, postorder);
                root.Right = helper(startPreOrder + 2, currentNodeIndex + 1, endPostOrder, preorder, postorder);
            }
            return root;

        }
    }
}
