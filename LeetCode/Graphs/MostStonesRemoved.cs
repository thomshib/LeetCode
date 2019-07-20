using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Graphs
{
    public class MostStonesRemoved
    {
        //https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3076/

        https://leetcode.com/articles/most-stones-removed-with-same-row-or-column/
        public int RemoveStones(int[][] stones)
        {
        /*
         * 
         * 
         * Input 1:
                A = [   [0, 0]
                        [0, 1]
                        [1, 0]
                        [1, 2]
                        [2, 2]
                        [2, 1]   ]
            Output 1:
                5
            Explanation 1:
                One of the order of removing stones:
                1. Remove (2,1) as it shares row with (2,2)
                    remaining stones ( (0,0), (0,1), (1,0), (1,2) and (2,2)).
                2. Remove (2,2) as it shares column with (1,2)
                    remaining stones ( (0,0), (0,1), (1,0) and (1,2)).
                3. Remove (0,1) as it shares row with (0,0)
                    remaining stones ( (0,0), (1,0) and (1,2)).
                4. Remove (1,2) as it shares row with (1,0)
                    remaining stones ( (0,0) and (1,0)).
                5. Remove (0,0) as it shares column with (1,0)
                    remaining stones ((1,0)).
               So the maximum number of moves is 5.
         * 
         * 
         * 
         * 
         * https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3076/discuss/224821/Java-easy-and-clean-DFS
         * 
         * https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3076/discuss/209369/Java-recursive-DFS-Short-and-easy-to-understand
         */

        // Ans = # of stones – # of islands
        //Time : O(N^2), N = # of stones
        //Space: O(N)
            int L = stones.GetLength(0);
            HashSet<int[]> visited = new HashSet<int[]>();
            int numOfIslands = 0;
            foreach(var item in stones)
            {
                if (!visited.Contains(item))
                {
                    DFS(stones, visited, item);
                    numOfIslands++;
                }
            }

            return L - numOfIslands;
        }

        private void DFS(int[][] stones, HashSet<int[]> visited, int[] item)
        {
            visited.Add(item);
            foreach(var nextItem in stones)
            {
                if (!visited.Contains(nextItem))
                {
                    // stone with same row or column. group them into island
                    if(item[0] == nextItem[0] || item[1] == item[1])
                    {
                        DFS(stones, visited, nextItem);
                    }
                }
            }
        }



        #region UnionFind



        #endregion



    }
}
