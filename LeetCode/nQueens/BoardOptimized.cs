using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.nQueens
{
    public class BoardOptimized
    {

        /*
        right diagonals have row + column = Constant
        left diagonals have row - column = Constant
        So, we can use row + column as an identifier for right diagonals and 
        row - column as an identifier for left diagonals.

        Using this idea, we can keep:

        a set of used right diagonals
        a set of used left diagonals
        a set of used columns
        */

        const string EMPTY_CHAR = ".";
        const string NON_EMPTY_CHAR = "Q";

        string[,] board;
        int N;


        List<int> cols;
        List<int> right_diags;
        List<int> left_diags;

        public BoardOptimized(int n)
        {
            cols = new List<int>();
            right_diags = new List<int>();
            left_diags = new List<int>();

            this.N = n;
            board = new string[N, N];

            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    board[r, c] = EMPTY_CHAR;
                }
            }

        }



        private bool IsValidMove(int row, int col)
        {
            return !cols.Contains(col)
                && !right_diags.Contains(row + col)
                && !left_diags.Contains(row - col);
            
        }

        private void PlaceQueen(int row, int col)
        {
            board[row, col] = NON_EMPTY_CHAR;
            cols.Add(col);
            right_diags.Add(row + col);
            left_diags.Add(row - col);
        }

        private void RemoveQueen(int row, int col)
        {
            board[row, col] = EMPTY_CHAR;
            cols.Remove(col);
            right_diags.Remove(row + col);
            left_diags.Remove(row - col);
        }

        public void PrintBoard()
        {
            Console.WriteLine("--------------Print Board----------");
            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    Console.Write(board[r, c] + " ");

                }
                Console.WriteLine();
            }

            Console.WriteLine("--------------#####----------");
            Console.WriteLine();
        }


        private bool DFS(int row)
        {
            if (row == N)
            {
                return true;
            }

            for (int col = 0; col < N; col++)
            {
                if (IsValidMove(row, col))
                {
                    PlaceQueen(row, col);

                    //call DFS recursively
                    //if not solved, backtrack and remove
                    if (DFS(row + 1))
                    {
                        return true;

                    }
                    //if we reach here, backtrack
                    RemoveQueen(row, col);
                }
            }

            return true;
        }

        public void SolveNQueens()
        {
            PrintBoard();
            DFS(0);
            PrintBoard();
        }

    }
}
