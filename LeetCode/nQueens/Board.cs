using System;
using System.Collections.Generic;
using System.Text;


//https://fizzbuzzed.com/top-interview-questions-3/
namespace LeetCode.nQueens
{
    public class Board
    {
        const string EMPTY_CHAR = ".";
        const string NON_EMPTY_CHAR = "Q";

        string[,] board;
        int N;

        public Board(int n)
        {
            this.N = n;
            board = new string[N, N];

            for(int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    board[r, c] = EMPTY_CHAR;
                }
            }
        }

        

        private bool IsValidMove(int row, int col)
        {
            int left_diag = col;
            int right_diag = col;

            for (int index = row; index >=0; index--)
            {
                if (board[index, col].Equals(NON_EMPTY_CHAR))
                {
                    return false;

                }

                if(left_diag >=0 && board[index, left_diag].Equals(NON_EMPTY_CHAR))
                {
                    return false;
                }

                if (right_diag < this.N && board[index, right_diag].Equals(NON_EMPTY_CHAR))
                {
                    return false;
                }
                left_diag--;
                right_diag++;
            }


            return true;
        }

        private void PlaceQueen(int row, int col)
        {
            board[row, col] = NON_EMPTY_CHAR;
        }

        private void RemoveQueen(int row, int col)
        {
            board[row, col] = EMPTY_CHAR;
        }

        public void PrintBoard()
        {
            Console.WriteLine("--------------Print Board----------");
            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    Console.Write(board[r, c]  + " " );
                    
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

            for(int  col = 0; col < N; col++)
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
