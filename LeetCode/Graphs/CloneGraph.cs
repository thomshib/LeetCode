using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Graphs
{
    //https://www.youtube.com/watch?v=vma9tCQUXk8
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/277/discuss/42309/Depth-First-Simple-Java-Solution

    // Definition for a Node.
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node() { }
        public Node(int _val, IList<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
        public class CloneGraph
    {
        /*
         * DFS search using Queue
         * Add the initial node to the queue
         * 
         * do while queue is not empty
         *   Pop the item from the queue and clone it
         *   Add the newly created to a Map and link it to its clone //this will be used as the "seen" data structure 
         *   Add the poped Node neighbors to the queue
         * 
         * end while
         */

        public Node CloneGraphSolution(Node node)
        {
            if (node == null)
            {
                return null;
            }

            Queue<Node> queue = new Queue<Node>();

            //maintains a relationship of the node to its clone
            Dictionary<Node, Node> dict = new Dictionary<Node, Node>();

            // Add the node to the queue
            // Add a clone of the node in the dict 
            queue.Enqueue(node);
            dict.Add(node, new Node(node.val,new List<Node>()));

            while(queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                //iterate over all neighbors
                foreach(var nextNode in currentNode.neighbors)
                {
                    if (!dict.ContainsKey(nextNode))
                    {
                        //No. add a clone 
                        // and then add it to the queue for edge traversal
                        dict.Add(nextNode, new Node(nextNode.val, new List<Node>()));
                        queue.Enqueue(nextNode);
                    }

                    // Add the edge from the currentNode clone to the nextNode clone

                    dict[currentNode].neighbors.Add(dict[nextNode]);
                }

            }

            //return the clone of the node
            return dict[node];
        }
    }
}
