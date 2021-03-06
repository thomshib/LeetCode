﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/305/
    public class ConstructBinaryTreefromPreorderInorderTraversal
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (inorder == null || inorder == null)
            {
                return null;
            }

            int pointerInOrder = 0;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node = null;

            TreeNode root = new TreeNode(preorder[0]);
            stack.Push(root);

            for (int i = 1; i < preorder.Length; i++)
            {
                TreeNode currNode = new TreeNode(preorder[i]);

                while (stack.Count > 0 && stack.Peek().val == inorder[pointerInOrder])
                {
                    node = stack.Pop();
                    pointerInOrder++;
                }

                if (node != null)
                {
                    node.Right = currNode;
                    node = null;
                }
                else
                {
                    stack.Peek().Left = currNode;
                }

                stack.Push(currNode);
            }

            return root;

        }


        /*
         * 
         *
         *  Say we have 2 arrays, PRE and IN.
            Preorder traversing implies that PRE[0] is the root node.
            Then we can find this PRE[0] in IN, say it's IN[5].
            Now we know that IN[5] is root, so we know that IN[0] - IN[4] is on the left side, IN[6] to the end is on the right side.
            Recursively doing this on subarrays, we can build a tree out of it :) 
         *        
         */
        public TreeNode BuildTreeRecursive(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0 || inorder == null || inorder.Length == 0)
            {
                return null;
            }

            return Helper(preorder, 0, inorder, 0, inorder.Length - 1);

            //return helper(0, 0, inorder.Length - 1, preorder, inorder);
        }


        private TreeNode Helper(int[] preorder, int rootIndex, int[] inorder, int start, int end)
        {

            if (rootIndex > preorder.Length - 1 || start > end)
            {
                return null;
            }

            TreeNode root = new TreeNode(preorder[rootIndex]);
            int rootInorderIndex = 0;
            for (int i = start; i <= end; i++)
            {

                if (inorder[i] == root.val)
                {
                    rootInorderIndex = i;
                    break;
                }
            }

            /*
             * Remember when we found the root in "inorder" array we immediately know how many nodes are on the left subtree and how many are on the right subtree
             *   Therefore the immediate right child index is rootIndex + numsOnLeft + 1 
             * 
             */
            int leftTreeLength = rootInorderIndex - start;

            root.Left = Helper(preorder, rootIndex + 1, inorder, start, rootInorderIndex - 1);
            root.Right = Helper(preorder, rootIndex + leftTreeLength + 1, inorder, rootInorderIndex + 1, end);
            return root;


        }




        private TreeNode helper(int startPreOrder, int startInOrder, int endInOrder, int[] preorder, int[] inorder)
        {
           if(startPreOrder > preorder.Length -1 || startInOrder > endInOrder)
            {
                return null;
            }

            TreeNode root = new TreeNode(preorder[startPreOrder]);

            int currentNodeIndex = 0;

            for(int i = startInOrder; i <= endInOrder; i++)
            {
                if(inorder[i] == root.val)
                {
                    currentNodeIndex = i;
                }
            }

            
            root.Left = helper(startPreOrder + 1, startInOrder, currentNodeIndex - 1, preorder, inorder);
            root.Right = helper(startPreOrder + 2, currentNodeIndex + 1, endInOrder, preorder, inorder);

            return root;

        }
    }
}
