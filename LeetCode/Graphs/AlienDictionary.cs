﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Graphs
{


    public class AlienDictionary
    {
        /*
         * Approach:
         * 
         * 
         * https://leetcode.com/problems/course-schedule-ii/discuss/190393/Topological-Sort-Template-General-Approach!!
         * 
         * Build Graph and Do Topological Sorting
         * 
         * Step 1: build a degree map for each character in all the words
                w:0
                w:0
                r:0
                t:0
                f:0
                e:0
         * 
         * 
         * Step 2: Then build the hashmap by comparing the adjacent words, 
         * 
         * the first character that is different between two adjacent words reflect the lexicographical order. 
         * For example:
         * "wrt", "wrf",
                first different character is 3rd letter, so t comes before f

           "wrf", "er",
                first different character is 1rd letter, so w comes before e

           The final HashMap "map" looks like.

                t -> set: f    
                w -> set: e
                r -> set: t
                e -> set: r
         *
         *And final HashMap "degree" looks like, the number means "how many letters come before the key":

            w:0
            r:1
            t:1
            f:1
            e:1
         * 
         * 
         * 
         */


        public string AlienOrder(string[] words)
        {
            if(words ==null || words.Length == 0)
            {
                return string.Empty;
            }

            Dictionary<char, HashSet<char>> graph = new Dictionary<char, HashSet<char>>();

            
            Dictionary<char, int> degreeMap = new Dictionary<char, int>();

            //initialize the degree map

            foreach(var stringItem in words)
            {
                foreach(var charItem in stringItem)
                {
                    if (!degreeMap.ContainsKey(charItem))
                    {
                        degreeMap.Add(charItem, 0);
                    }
                }
            }

            #region BuildGraph
            //build graph and update degree for each char
            int n = words.Length;
            for(int i = 0; i < n - 1; i++)
            {
                var currentWord = words[i];
                var nextWord = words[i + 1];
                int minLength = Math.Min(currentWord.Length, nextWord.Length);

                for (int j = 0; j < minLength; j++){
                    char parent = currentWord[j];
                    char child = nextWord[j];

                    //build currentChar -> nextChar relationship
                    if(parent != child)
                    {
                        if (!graph.ContainsKey(parent))
                        {
                            graph.Add(parent, new HashSet<char>());
                        }

                        HashSet<char> charSet = graph[parent];

                        /* avoid duplicate maps
                        * eg: for the input: {"za", "zb", "ca", "cb"}, we have two pairs of a -> b relationship
                        * if we increase inDegree value of 'b' again, the final result will not have 'b', since
                        * inDegree of b will stay on 1 when queue is empty
                        * correct graph: a->b, z->c
                        * incorrect graph: a->b, a->b, z->c
                        */

                        if (!charSet.Contains(child))
                        {
                            charSet.Add(child);
                            graph[parent] = charSet;

                            //update degree map

                            degreeMap[child]++;
                        }

                        /* we can determine the order of characters ony by first different pair of characters 
                         * so we cannot add relationship  by the rest of characters */
                        break;

                    }
                }
            }

            #endregion


            #region ProcessGraph 
            //Topological Sorting

            StringBuilder sb = new StringBuilder();
            Queue<char> queue = new Queue<char>();

            /* put all starting node into queue, which means put all nodes that have inDegree = 0 */
            foreach(var key in degreeMap.Keys)
            {
                if(degreeMap[key] == 0)
                {
                    queue.Enqueue(key);
                }
            }


            /* BFS traversal to build the result */

            while(queue.Count > 0)
            {
                char currentChar = queue.Dequeue();
                sb.Append(currentChar);

                /* traverse all next node of current node in graph; update degreeMap value; put all nodes with zero degree in queue */

                if (graph.ContainsKey(currentChar))
                {
                    foreach(var nextChar in graph[currentChar])
                    {
                        if (degreeMap.ContainsKey(nextChar))
                        {
                            degreeMap[nextChar]--;
                        }
                        if(degreeMap[nextChar] == 0)
                        {
                            queue.Enqueue(nextChar);
                        }
                    }

                }



            }


            if (sb.Length != degreeMap.Count) return string.Empty;

            return sb.ToString();


            #endregion


        }



        public string AlienOrderAgain(string[] words)
        {


            Dictionary<char,List<char>> graph = new Dictionary<char,List<char>>();
        Dictionary<char,int> inDegree = new Dictionary<char,int>();
        string result = "";
        
        if(words == null || words.Length == 0) return result;
        
        //initialize
        foreach(var word in words){
            foreach(var character in word){
                if(!graph.ContainsKey(character)){
                    graph.Add(character, new List<char>());
                    inDegree.Add(character,0);
                }
            }
        }
        
        //build
        for(int i = 0; i < words.Length - 1 ; i++){
            var word1 = words[i];
            var word2 = words[i+1];
            if(word1.Length > word2.Length && word1.StartsWith(word2)) return ""; // "abc", "ab" should return""
            int L = Math.Min(word1.Length, word2.Length);
            for(int j = 0; j < L ; j++){
                var parent = word1[j];
                var child = word2[j];
                
                
                if(parent != child){
                    if(!graph[parent].Contains(child)){
                    graph[parent].Add(child);
                    inDegree[child]++;
                    
                    }
                    break;
                }
                
            }
        }
        
        Queue<char> queue = new Queue<char>();
        
        foreach(var item in inDegree){
            if(item.Value == 0){
                queue.Enqueue(item.Key);
            }
        }
        
        StringBuilder sb = new StringBuilder();
        
        while(queue.Count > 0){
            var current = queue.Dequeue();
            sb.Append(current);
            foreach(var next in graph[current]){
                inDegree[next]--;
                if(inDegree[next] == 0){
                    queue.Enqueue(next);
                }
            }
        }
        
        result = sb.ToString();
        
        if(result.Length != inDegree.Count) return "";
        
        return result;
              



        }

    }
}
