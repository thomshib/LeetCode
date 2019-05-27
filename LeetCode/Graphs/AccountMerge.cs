using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Graphs
{

    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/3027
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/3027/discuss/109157/JavaC++-Union-Find
    public class AccountMerge
    {
        //Graph + BFS solutions
        /*
         * 
         * Name1  - a,b,c
         * Name2 -  c,d,a
         * 
         * Create a graph of email that all emails with same name
         *  a - [b,c,d]
         *  b - [a,c]
         *  c - [b,d]
         *  d - [c,a]
         *  
         *  
         *  
         * create a map of email to name,one to one mapping for finding name by any email belong to same group
         * a - Name1
         * b - Name1
         * 
         * 
         * 
         * 
         * 
         * 
         */
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            Dictionary<String, HashSet<string>> graph = new Dictionary<string, HashSet<string>>(); //email to neighbors relationship
            Dictionary<string, string> emailToNameMap = new Dictionary<string, string>(); //email to accountname mapping

            //Build the Graph
            foreach(var listItem in accounts)
            {
                string accountName = listItem[0];
                int n = listItem.Count;

                for(int i = 1; i < n; i++) //skip name
                {
                    if (!graph.ContainsKey(listItem[i]))
                    {
                        graph[listItem[i]] = new HashSet<string>();
                    }

                    if( i != 1) // add both a to b and b to a email relationships
                    {
                        graph[listItem[i - 1]].Add(listItem[i]);
                        graph[listItem[i]].Add(listItem[i -1]);
                    }

                    emailToNameMap.Add(listItem[i], accountName);
                }

            }


            //Process the Graph
            //BFS
            List<IList<string>> result = new List<IList<string>>();

            HashSet<string> visited = new HashSet<string>();
            
            foreach(var email in graph.Keys)
            {
                if (!visited.Contains(email))
                {
                    visited.Add(email);

                    List<string> newList = BFS(graph, visited, email);
                    newList.Sort();
                    newList.Insert(0, emailToNameMap[newList[0]]);  // warning: don't use email as it may have been visited
                    result.Add(newList);
                }
            }

            return result;

        }

        private List<string> BFS(Dictionary<string, HashSet<string>> graph, HashSet<string> visited, string email)
        {
            List<string> result = new List<string>();
            Queue<string> queue = new Queue<string>();

            queue.Enqueue(email);

            while(queue.Count > 0)
            {
                int size = queue.Count;
                string currentEmail;

                for(int i = 0; i < size; i++)
                {
                    currentEmail = queue.Dequeue();
                    result.Add(currentEmail);

                    foreach(var neighbor in graph[currentEmail])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }

                
            }
            return result;

        }
    }
}
