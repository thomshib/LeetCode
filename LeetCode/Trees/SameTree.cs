using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/306/
    public class TreeNode
    {
        public int val;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode(int x)
        {
            val = x;
        }

    }


    public class SameTree
    {

        public bool IsSameTree(TreeNode p, TreeNode q)
        {

            if(p == null && q == null)
            {
                return true;
            }

            if(p ==null || q == null || p.val != q.val)
            {
                return false;
            }

            return IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right);
        }

        public bool IsSameTreeIterative(TreeNode p, TreeNode q)
        {

            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null || p.val != q.val)
            {
                return false;
            }

            Queue<TreeNode> queueP = new Queue<TreeNode>();
            Queue<TreeNode> queueQ = new Queue<TreeNode>();

            queueP.Enqueue(p);
            queueQ.Enqueue(q);

            while(queueP.Count >0 && queueQ.Count > 0)
            {
                TreeNode node1 = queueP.Dequeue();
                TreeNode node2 = queueQ.Dequeue();

                if(node1.val != node2.val)
                {
                    return false;
                }

                if(node1.Left == null ^ node2.Left == null)
                {
                    return false;
                }

                if (node1.Right == null ^ node2.Right == null)
                {
                    return false;
                }

                if(node1.Left != null)
                {
                    queueP.Enqueue(node1.Left);
                    queueQ.Enqueue(node2.Left);
                }

                if (node1.Right != null)
                {
                    queueP.Enqueue(node1.Right);
                    queueQ.Enqueue(node2.Right);
                }
            }

            return true;
        }
    }
}
