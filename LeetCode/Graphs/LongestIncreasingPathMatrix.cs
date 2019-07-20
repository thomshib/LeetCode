using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Graphs
{

    //https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3072


    //https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3072/discuss/78308/15ms-Concise-Java-Solution

    //Approach
    /*
     *  Do DFS from every cell
        Compare every 4 direction and skip cells that are out of boundary or smaller
        Get matrix max from every cell's max
        
        The key is to cache the distance because it's highly possible to revisit a cell
     * 
     * 
     * 
     * 
     */
    public class LongestIncreasingPathMatrix
    {

        /** 
 * DFS + Memoization 
 * 
 * Traverse all points in matrix, use every point as starting point to do dfs traversal. DFS function returns max increasing 
 * path after comparing four max return distance from four directions. 
 * 
 * @param cache: cache[i][j] represents longest increasing path starts from point matrix[i][j]
 * @param prev: previous value used by DFS traversal, to compare whether current value is greater than previous value
 * */
        static readonly int[][] dirs = new int[][] {
            new int[]{ 1, 0 },
            new int[]{-1,0 },
             new int[]{0,1 },
              new int[]{0,-1 }


        };
        public int LongestIncreasingPath(int[][] matrix)
        {
            int m = matrix.GetLength(0);

            if (m == 0) return 0;

            int n = matrix[0].Length;

            int result = 0;
            int[,] cache = new int[m, n];
            for(int i = 0; i < m; i++)
            {
                for(int j=0; j < n; j++)
                {
                    int currentLength = DFS(matrix, cache, i, j, m, n, matrix[i][j]);
                    result = Math.Max(result, currentLength);
                }
            }

            return result;


        }

        private int DFS(int[][] matrix, int[,] cache, int x, int y, int m, int n, int currentValue)
        {
            if (cache[x, y] != 0) return cache[x, y];

            //initialize max distance as 1 since the path includes starting point itself
            int max = 1;

            foreach(var dir in dirs)
            {
                int dx = x + dir[0];
                int dy = y + dir[1];

                // if next point is out of bound or next point current point is greater than or equal to next point

                if (dx < 0 || dx > m - 1 || dy < 0 || dy > n - 1 || currentValue >= matrix[dx][dy]) continue;

                // if next point is a valid point, add curLen by 1 and continue DFS traversal
                int currentLength = 1 + DFS(matrix, cache, dx, dy, m, n, matrix[dx][dy]);
                max = Math.Max(currentLength, max);
            }

            // update max increasing path value starting from current point in cache
            cache[x, y] = max;
            return max;
        }
    }
}
