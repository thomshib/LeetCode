using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeTest.Graphs
{
    //https://www.youtube.com/watch?v=vma9tCQUXk8
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/277/discuss/42309/Depth-First-Simple-Java-Solution

   
        [TestClass]
        public class CloneGraphTests
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
        
        [TestMethod]
        public void CloneGraphSolutionResultsInSuccess()
        {
            var node1 = new Node(1, new List<Node>());
            var node2 = new Node(2, new List<Node>());
            var node3 = new Node(3, new List<Node>());
            var node4 = new Node(4, new List<Node>());

            node1.neighbors.Add(node2);
            node1.neighbors.Add(node4);


            node2.neighbors.Add(node1);
            node2.neighbors.Add(node3);

            node3.neighbors.Add(node2);
            node3.neighbors.Add(node4);

            
            node4.neighbors.Add(node1);
            node4.neighbors.Add(node3);

            var expectedResult = DFS(node1);

            var result = new CloneGraph().CloneGraphSolution(node1);

            var actualResult = DFS(result);

            var areEqual = CollectionsAreEqual.AreEqual(actualResult, expectedResult,new GraphComparer());

            Assert.IsTrue(areEqual);


        }


        private IList<Node> DFS(Node start)
        {
            var result = new List<Node>();
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(start);
            result.Add(start);

            while (queue.Count> 0)
            {
                var node = queue.Dequeue();
                

                foreach(var nextNode in node.neighbors)
                {
                    if (!result.Contains(nextNode))
                    {
                        result.Add(nextNode);                    
                        queue.Enqueue(nextNode);
                    }
                }
            }


            return result;
        }
    }
}
