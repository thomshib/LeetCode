using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Graphs
{
    public class CrackingSafe
    {

        //https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3075/

        //https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3075/discuss/153039/DFS-with-Explanations

        //https://leetcode.com/problems/cracking-the-safe/discuss/110264/Easy-DFS

        public string CrackSafe(int n, int k)
        {
            /*
             * https://www.youtube.com/watch?v=iPLQgXUiU14
             * 
             * Approach
             * In order to guarantee to open the box at last, the input password ought to contain all length-n combinations on digits
             * there should be k^n combinations in total.
             * e.g., n = 2, k = 2
                all 2-length combinations on [0, 1]: 
                00 (`00`110), 
                 01 (0`01`10), 
                  11 (00`11`0), 
                   10 (001`10`)
   
                the password is 00110
             * 
             * 
             * We can utilize DFS to find the password:

                goal: to find the shortest input password such that each possible n-length combination of digits [0..k-1] occurs exactly once as a substring.

                node: current input password

                edge: if the last n - 1 digit of node1 can be transformed to node2 by appending a digit from 0..k-1, there will be an edge between node1 and node2

                start node: n repeated 0's
                end node: all n-length combinations among digits 0..k-1 are visited

                visitedComb: all combinations that have been visited
             * 
             * 
             */

            // Initialize pwd to n-1 repeated 0's as the start node of DFS.
            // n-1 becaz we do not want to backtrack
            String startNode = new String('0', n - 1);
            StringBuilder result = new StringBuilder(startNode);

            HashSet<string> visitedNodes = new HashSet<string>();
            visitedNodes.Add(startNode);

            //int totalCount = (int) Math.Pow(k, n);

            DFS(result, visitedNodes,startNode,k);

            return result.ToString();

        }

        //00 -> 01 -> 10 -> 11 -> 
        private void DFS(StringBuilder result, HashSet<string> visitedNodes, string node, int k)
        {
            

            for(var i = 0; i < k; i++)
            {
                string newPassword = node + i;
                if (!visitedNodes.Contains(newPassword))
                {
                    visitedNodes.Add(newPassword);
                    DFS(result, visitedNodes, newPassword.Substring(1), k); //substring index 1 onwards; skip 0th char
                    result.Append(i);

                      
                  
                }
            }

            
        }
    }
}
