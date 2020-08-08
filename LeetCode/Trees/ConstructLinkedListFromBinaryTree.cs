using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    public class ConstructLinkedListFromBinaryTree
    {
        //https://www.youtube.com/watch?v=FsxTX7-yhOw
        //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/544/
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



        //Approach is to do Inorder Traversal
        public TreeNode ConstructLinkedListIterative(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            //Step 1

            if (root == null)
            {
                return null;
            }
            TreeNode head = null;
            TreeNode last = null;
            Stack<TreeNode> stack = new Stack<TreeNode>();

           while(root != null || stack.Count > 0){
            
            while(root != null){
                stack.Push(root);
                root = root.left;
            }
            root = stack.Pop();
            
            if(head == null){
                head = root;
            }else{
                root.left = last;
                last.right = root;
                
            }
            last = root;
            root = root.right;
        }

            last.Right = head;
            head.Left = last;
            return head;



        }
    }
}
