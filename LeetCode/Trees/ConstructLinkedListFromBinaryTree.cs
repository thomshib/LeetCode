using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    public class ConstructLinkedListFromBinaryTree
    {
        //https://www.youtube.com/watch?v=FsxTX7-yhOw
        //
        private static TreeNode previous = null;

        /**
         * Do Inorder Traversal
         *  1. Go to Left
         *  2. Process node
         *  3. Go to Right
         * 
         * step1: inorder tranversal by recursion to connect the original BST
           step2: connect the head and tail to make it circular

            Tips: Using dummy node to handle corner case

            Node prev = null;
            public Node treeToDoublyList(Node root) {
	            if (root == null) return null;
	            Node dummy = new Node(0, null, null);
	            prev = dummy;
	            helper(root);
	            //connect head and tail
	            prev.right = dummy.right;
	            dummy.right.left = prev;
	            return dummy.right;
            }

            private void helper (Node cur) {
	            if (cur == null) return;
	            helper(cur.left);
	            prev.right = cur;
	            cur.left = prev;
	            prev = cur;
	            helper(cur.right);
            }
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


        public TreeNode ConstructLinkedListIterative(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            //Step 1

            TreeNode dummy = new TreeNode(-1);
            dummy.Left = null;
            dummy.Right = null;

            TreeNode previous = dummy;

            Stack<TreeNode> stack = new Stack<TreeNode>();

            while(node != null || stack.Count > 0)
            {
                
                //Step 1 - go the left

                while(node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                //Step 2 - Process left most node
                
                    node = stack.Pop();
                
                if(previous != null)
                {
                    previous.Right = node;
                    node.Left = previous;
                }

                //Step 3 - Go to the right
                previous = node;
                node = node.Right;
            }

            previous.Right = dummy.Right;
            dummy.Right.Left = previous;

            return dummy.Right;
           

        }
    }
}
