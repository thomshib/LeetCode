using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Graphs
{
    //https://leetcode.com/problems/walls-and-gates/
    //https://www.youtube.com/watch?v=Pj9378ZsCh4
    //
    public class WallsAndGates
    {
        public void WallsAndGatesSolution(int[][] rooms)
        {
            for (int row =0; row < rooms.GetLength(0); row++)
            {
                for(int col=0; col< rooms[row].Length; col++)
                {
                    if (rooms[row][col] == 0)
                    {
                        DFS(row, col, 0, rooms);
                    }
                }
            }
        }

        private void DFS(int row, int col, int count, int[][] rooms)
        {
            if( row < 0 || row >= rooms.GetLength(0) || col < 0 ||  col >= rooms[row].Length || rooms[row][col] < count)
            {
                return;
            }

            rooms[row][col] = count;
            DFS(row + 1, col, count + 1, rooms);
            DFS(row - 1, col, count + 1, rooms);
            DFS(row, col + 1, count + 1, rooms);
            DFS(row, col - 1 , count + 1, rooms);

        }
    }
}
