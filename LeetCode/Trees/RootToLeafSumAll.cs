using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    public class RootToLeafSumAll
    {
        // output all root to leaf sums of a binary tree


        public List<int> CalulateSum(TreeNode node)
        {
            List<int> result = new List<int>();

            if(node == null)
            {
                return result;
            }

            DFS(node, result, 0);

            return result;



        }

        private void DFS(TreeNode node, List<int> result, int sum)
        {
            if(node == null)
            {
                return;
            }
           if( node.Left == null && node.Right == null) //leaf node
            {
                sum += node.val;
                result.Add(sum);
                return;
            }
            

            DFS(node.Left, result, sum + node.val);
            DFS(node.Right, result, sum + node.val);

           

        }
    }
}
