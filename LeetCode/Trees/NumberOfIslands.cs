using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{
    //https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/274/
    //https://www.youtube.com/watch?v=o8S2bO3pmO4
    public class NumberOfIslands
    {

        public int NumIslands(char[][] grid)
        {
            int nums = 0;

            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        nums += DFS(grid, i, j);
                    }
                }
            }
            return nums;
        }

        private int DFS(char[][] grid, int i, int j)
        {
            if(i < 0 || i >= grid.GetLength(0) || j < 0 || j >= grid[i].Length || grid[i][j] == '0')
            {
                return 0;
            }

            //collapse the island, 
            grid[i][j] = '0'; //prevents revisiting;

            DFS(grid, i - 1, j);
            DFS(grid, i + 1, j);
            DFS(grid, i, j - 1);
            DFS(grid, i, j + 1);

            return 1; //for the i,j which was 1
        }
    }
}
