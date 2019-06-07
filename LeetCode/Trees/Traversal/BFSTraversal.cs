using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees.Traversal
{
    public class BFSTraversal
    {

        public IList<List<int>> LevelOrder(TreeNode root)
        {
            List<List<int>> result = new List<List<int>>();

            if(root == null)
            {
                return result;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            

            while(queue.Count > 0)
            {
                
                var nodeList = new List<int>();
                int count = queue.Count;
                    for(int i = 0; i < count; i++)
                    {
                        var node = queue.Dequeue();
                        nodeList.Add(node.val);

                    if (node.Left != null)
                        {
                        
                            queue.Enqueue(node.Left);
                        }

                        if (node.Right != null)
                        {
                        
                            queue.Enqueue(node.Right);
                        }

                        

                    }

                    result.Add(nodeList);
                }

                
            

            return result;
        }
    }
}
