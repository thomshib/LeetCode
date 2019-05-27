using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Graphs
{
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/3028/
    public class BipartiteGraph


    {
        /*
         * 
         * Our goal is trying to use two colors to color the graph and see if there are any adjacent nodes having the same color.
            Initialize a color[] array for each node. Here are three states for colors[] array:
            0: Haven't been colored yet.
            1: Blue.
            -1: Red.
            For each node,

            If it hasn't been colored, use a color to color it. Then use the other color to color all its adjacent nodes (DFS).
            If it has been colored, check if the current color is the same as the color that is going to be used to color it. 
         * 
         * 
         * 
         * 
         * 
         * 
         */


        public bool IsBipartiteRecursive(int[][] graph)
        {
            int n = graph.GetLength(0);

            if (n == 0)
            {
                return false;
            }

            int[] colors = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (colors[i] == 0 && !IsValidColor(graph, colors, 1, i))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsValidColor(int[][] graph, int[] colors, int color, int node)
        {
            if (colors[node] != 0)
            {
                return colors[node] == color;
            }

            colors[node] = color;
            foreach (var nextNode in graph[node])
            {
                if (!IsValidColor(graph, colors, -color, nextNode))
                {  //try to color the neighbors with a differenct color
                    return false;
                }
            }

            return true;
        }


        public bool IsBipartiteIterative(int[][] graph)
        {
            int n = graph.GetLength(0);

            if (n == 0)
            {
                return false;
            }

            int[] colors = new int[n];
           
            for (int i = 0; i < n; i++)
            {
                if (colors[i] != 0) continue;
                colors[i] = 1;
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(i);

                while(queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    foreach(var nextNode in graph[node])
                    {
                        if(colors[nextNode] == 0)
                        {
                            colors[nextNode] = -colors[node];
                            queue.Enqueue(nextNode);
                        }else if(colors[nextNode] != -colors[node])
                        {
                            return false;
                        }
                    }
                }



            }

            return true;
        }
    }
}
