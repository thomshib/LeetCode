using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{

    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/298/
    //https://www.youtube.com/watch?v=PQKkr036wRc
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/298/discuss/76401/5ms-Java-Clean-Solution
    public class BinaryTreeVerticalOrderTraversal
    {
        public List<List<int>> VerticalOrder(TreeNode root)
        {
            var result = new List<List<int>>();

            var map = new Dictionary<int, List<int>>();

            var nodeQueue = new Queue<TreeNode>();
            var distanceQueue = new Queue<int>();
            int min = 0;
            int max = 0;

            nodeQueue.Enqueue(root);
            distanceQueue.Enqueue(0);

            while(nodeQueue.Count > 0)
            {
                var node = nodeQueue.Dequeue();
                var distance = distanceQueue.Dequeue();

                if (!map.ContainsKey(distance))
                {
                    map.Add(distance, new List<int>());
                }

                map[distance].Add(node.val);

                if(node.Left != null)
                {
                    nodeQueue.Enqueue(node.Left);
                    distanceQueue.Enqueue(distance - 1);
                    min = Math.Min(min, distance - 1);
                }

                if (node.Right != null)
                {
                    nodeQueue.Enqueue(node.Right);
                    distanceQueue.Enqueue(distance + 1);
                    max = Math.Max(max, distance + 1);
                }
            }

            for(int i = min; i <=max; i++)
            {
                result.Add(new List<int>(map[i]));
            }


            return result;
        }
    }
}
