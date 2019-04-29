using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    public class ConstructLinkedListFromBinaryTree
    {
        private static TreeNode previous = null;

        /**
         * Do Inorder Traversal
         *  1. Go to Left
         *  2. Process node
         *  3. Go to Right
         * 
         * 
         * 
         * 
         * 
         * 
         */

        public void ConstructLinkedList(TreeNode node, TreeNode head)
        {
            if(node == null)
            {
                return;
            }

            //Step 1

            previous = null;
            ConstructLinkedList(node.Left, head);

            //Step 2
            if(previous == null)
            {
                head = node;
            }
            else
            {
                node.Left = previous;
                previous.Right = node;
            }
            previous = node;

            //Step 3
            ConstructLinkedList(node.Right, head);

        }
    }
}
