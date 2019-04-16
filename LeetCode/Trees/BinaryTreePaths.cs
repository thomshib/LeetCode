using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{

    //https://www.techiedelight.com/preorder-tree-traversal-iterative-recursive/

    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/280/
    public class BinaryTreePaths
    {
        public IList<string> BinaryTreePathsRecursive(TreeNode root)
        {
            List<string> nodes = new List<string>();
            if (root != null)
            {
                SearchTree(root, "", nodes);
            }

            return nodes;
        }

        private void SearchTree(TreeNode root, string path, List<string> nodes)
        {

            if (root.Left == null && root.Right == null) nodes.Add(path + root.val);
            if (root.Left != null) SearchTree(root.Left, path + root.val + "->", nodes);
            if (root.Right != null) SearchTree(root.Right, path + root.val + "->", nodes);
        }


        public IList<string> BinaryTreePathsIterative(TreeNode root)
        {
            List<string> nodes = new List<string>();
            Stack<Tuple<TreeNode, string>> stack = new Stack<Tuple<TreeNode, string>>();

            if (root != null)
            {
                stack.Push(new Tuple<TreeNode, string>(root, ""));
            }

            while(stack.Count > 0)
            {
                var pair = stack.Pop();
                var currNode = pair.Item1;
                var path = pair.Item2;

                if(currNode.Left ==null && currNode.Right == null)
                {
                    nodes.Add(path + currNode.val);
                }

                if(currNode.Right != null)
                {
                    stack.Push(new Tuple<TreeNode, string>(currNode.Right, path + currNode.val + "->"));
                }

                if (currNode.Left != null)
                {
                    stack.Push(new Tuple<TreeNode, string>(currNode.Left, path + currNode.val + "->"));
                }
            }

            return nodes;
        }
    }
}
