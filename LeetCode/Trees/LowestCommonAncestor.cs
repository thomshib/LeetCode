using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/3024/
    //https://www.youtube.com/watch?v=13m9ZCB8gjw
    public class LowestCommonAncestorSolution
    {

        //if a substree contains both p & q, then parent is the result;
        //if one of them is present, result is one of them
        //if none of them are present, then result is null
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {

            if(root == null || root == p || root == q)
            {
                return root;
            }

            //traverse the left and right subtree of the root
            TreeNode leftNode = LowestCommonAncestor(root.Left, p, q);
            TreeNode rightNode = LowestCommonAncestor(root.Right, p, q);

            if(leftNode != null && rightNode != null) //both p & q found in the subtree of root
            {
                return root;
            }
            else if(leftNode == null && rightNode != null)
            {
                return rightNode;
            }
            else if (rightNode == null && leftNode != null)
            {
                return leftNode;
            }
            else
            {
                return null;
            }

           

        }

        /*
        Approach 2: Iterative using parent pointers

        Intuition:

            If we have parent pointers for each node we can traverse back from p and q to get their ancestors.
            The first common node we get during this traversal would be the LCA node. We can save the parent pointers in a dictionary 
            as we traverse the tree.

        Algorithm:

            Start from the root node and traverse the tree.
            Until we find p and q both, keep storing the parent pointers in a dictionary.
            Once we have found both p and q, we get all the ancestors for p using the parent dictionary and add to a set called ancestors.
            Similarly, we traverse through ancestors for node q.If the ancestor is present in the ancestors set for p, 
            this means this is the first ancestor common between p and q (while traversing upwards) and hence this is the LCA node.
            
        Analysis:

            Time Complexity : O(N), where N is the number of nodes in the binary tree. 
            In the worst case we might be visiting all the nodes of the binary tree.

            Space Complexity : O(N). In the worst case space utilized by the stack, 
            the parent pointer dictionary and the ancestor set, would be N each, since the height of a skewed binary tree could be N. 
       
     */
        public TreeNode LowestCommonAncestorIterative(TreeNode root, TreeNode p, TreeNode q)
     {
            if (root == null)
            {
                return null;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            Dictionary<TreeNode, TreeNode> parentMap = new Dictionary<TreeNode, TreeNode>(); //map from node to parent
            stack.Push(root);
            parentMap[root] = null;

            //iterate untill we find both the nodes p & q
            while (!parentMap.ContainsKey(p) || !parentMap.ContainsKey(q))
            {
                TreeNode node = stack.Pop();

                if(node.Left != null)
                {
                    parentMap[node.Left] = node;
                    stack.Push(node.Left);
                    
                }

                if (node.Right != null)
                {
                    parentMap[node.Right] = node;
                    stack.Push(node.Right);

                }
            }

            HashSet<TreeNode> ancestors = new HashSet<TreeNode>();

            //Process all ancestors for node p using parent pointers
            while (p != null)
            {
                ancestors.Add(p);
                p = parentMap[p];
            }

            //the first ancestor of q that appears in 
            //p's ancestor set() is the lowest common ancestor

            while (!ancestors.Contains(q))
            {
                q = parentMap[q];
            }

            return q;
      }
    }
  }

