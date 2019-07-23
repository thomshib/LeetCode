using System;
using System.Collections.Generic;
using System.Text;
using LeetCodeTest.Graphs;

namespace LeetCode.Graphs
{

//https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/197/
//https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/197/discuss/33815/My-accepted-JAVA-solution
public class ZigzagTraversal{

    /*
        Approach use BinaryLevelOrder Traversal
    
    
    
    */
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        List<IList<int>> result = new List<IList<int>>();

        if(root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        bool zigzag = false;

        while(queue.Count > 0){
            List<int> items = new List<int>();
            int size = queue.Count;
            for(int i = 0; i < size; i++){
                var node = queue.Dequeue();
                if(zigzag){ //right to left
                    items.Insert(0,node.val);
                }else{
                    items.Add(node.val); //left to right
                }

                if(node.left != null){
                    queue.Enqueue(node.left);
                }
                if(node.right != null){
                    queue.Enqueue(node.right);
                }
            }

            result.Add(items);
            zigzag = !zigzag;
        }

        return result;
   
        
    }
}

}