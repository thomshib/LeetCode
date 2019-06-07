using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Graphs
{


    public class AlienDictionary
    {
        /*
         * Approach:
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
                    char currentChar = currentWord[j];
                    char nextChar = nextWord[j];

                    //build currentChar -> nextChar relationship
                    if(currentChar != nextChar)
                    {
                        if (!graph.ContainsKey(currentChar))
                        {
                            graph.Add(currentChar, new HashSet<char>());
                        }

                        HashSet<char> charSet = graph[currentChar];

                        /* avoid duplicate maps
                        * eg: for the input: {"za", "zb", "ca", "cb"}, we have two pairs of a -> b relationship
                        * if we increase inDegree value of 'b' again, the final result will not have 'b', since
                        * inDegree of b will stay on 1 when queue is empty
                        * correct graph: a->b, z->c
                        * incorrect graph: a->b, a->b, z->c
                        */

                        if (!charSet.Contains(nextChar))
                        {
                            charSet.Add(nextChar);
                            graph[currentChar] = charSet;

                            //update degree map

                            degreeMap[nextChar]++;
                        }

                        /* we can determine the order of characters ony by first different pair of characters 
                         * so we cannot add relationship  by the rest of characters */
                        break;

                    }
                }
            }

            #endregion


            #region ProcessGraph

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

            if (words == null || words.Length == 0)
            {
                return string.Empty;
            }

            Dictionary<char, HashSet<char>> graph = new Dictionary<char, HashSet<char>>();
            Dictionary<char, int> degreeMap = new Dictionary<char, int>();

            //initialize degree

            foreach (var wordItem in words)
            {
                foreach (var charItem in wordItem)
                {

                    if (!degreeMap.ContainsKey(charItem))
                    {
                        degreeMap.Add(charItem, 0);
                    }
                }
            }


            //build graph

            int n = words.Length;

            for (int i = 0; i < n - 1; i++)
            {

                var currentWord = words[i];
                var nextWord = words[i + 1];

                int minLength = Math.Min(currentWord.Length, nextWord.Length);

                for (int j = 0; j < minLength; j++)
                {

                    var currentChar = currentWord[j];
                    var nextChar = nextWord[j];

                    if (currentChar != nextChar)
                    {

                        if (!graph.ContainsKey(currentChar))
                        {
                            graph.Add(currentChar, new HashSet<char>());
                        }

                        var charSet = graph[currentChar];

                        if (!charSet.Contains(nextChar))
                        {
                            charSet.Add(nextChar);
                            degreeMap[nextChar]++;
                        }

                        break;
                    }

                }

            }


            //process graph

            Queue<char> queue = new Queue<char>();
            StringBuilder sb = new StringBuilder();
            foreach (var charKey in degreeMap.Keys)
            {
                if (degreeMap[charKey] == 0)
                {
                    queue.Enqueue(charKey);
                }

            }

            while (queue.Count > 0)
            {
                var charItem = queue.Dequeue();
                sb.Append(charItem);

                foreach (var item in graph[charItem])
                {

                    if (degreeMap.ContainsKey(item))
                    {
                        degreeMap[item]--;

                        if (degreeMap[item] == 0)
                        {
                            queue.Enqueue(item);
                        }

                    }


                }

            }

            if (sb.Length != degreeMap.Count) return String.Empty;

            return sb.ToString();

        }

    }
}
