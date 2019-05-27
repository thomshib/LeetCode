using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Graphs
{
    public class ShortestDistancefromAllBuildings
    {
        //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/3026/



        /*
         * Count the total # of buildings; store that in buildingCount
         * 
         * foreach empty node, 
         *  1- calculate the cumulative distance from all buildings; store that in distance[][]
         *  2- maintain the count of reachable buildings from this empty node; store that in reachable[][]
         * 
         * 
         * Traverse the distance array to get the smallest cumulative distance
         * 
         * 
         */

        readonly int[][] dir = new int[][]{ 
            new int[]{ 0, 1 }, 
            new int[]{ 0, -1 }, 
            new int[]{ 1, 0 }, 
            new int[]{ -1, 0 }
        };

        public int ShortestDistance(int[][] grid)
        {
            if(grid.GetLength(0) == 0  || grid[0].Length == 0)
            {
                return 0;
            }

            int m = grid.GetLength(0);
            int n = grid[0].Length;

            int totalBuildings = 0;

            int[,] distance = new int[m, n];
            int[,] reachable = new int[m, n];

            Queue<int[]> queue = new Queue<int[]>();

            //BFS search; 

            for(int i = 0; i < m; i++)
            {
                for(int j=0; j < n; j++)
                {
                    if(grid[i][j] == 1) //building
                    {
                        queue.Enqueue(new int[] { i, j });
                        totalBuildings++;
                        BFS(grid, queue, distance, reachable, n, m);
                    }
                }
            }


            //Iterate the distacnce to find the min sum

            int result = int.MaxValue;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 0  && reachable[i,j] == totalBuildings) 
                    {
                        result = Math.Min(result, distance[i, j]);
                    }
                }
            }

            return result == int.MaxValue ? -1 : result; 










        }

        private void BFS(int[][] grid, Queue<int[]> queue, int[,] distance, int[,] reachable, int n, int m)
        {
            int level = 1;
            bool[,] visited = new bool[m, n];

            while(queue.Count> 0)
            {
                //process current level nodes
                int layerCount = queue.Count;

                for(int i = 0; i < layerCount; i++)
                {
                    int[] currentNode = queue.Dequeue();
                    int x = currentNode[0];
                    int y = currentNode[1];

                    for (int j = 0; j < 4; j++)
                    {
                        //check top, bottom, left, right nodes

                        int dx = x + dir[j][0];
                        int dy = y + dir[j][1];

                        if( dx < 0  || dx > m -1  || dy < 0 || dy > n - 1 || visited[dx,dy] || grid[dx][dy] !=0   )
                        {
                            continue;
                        }

                        queue.Enqueue(new int[] { dx, dy });
                        visited[dx, dy] = true;
                        distance[dx, dy] += level; 
                        reachable[dx, dy]++;
                    }
                }
                level++;

            }
        }
    }
}
