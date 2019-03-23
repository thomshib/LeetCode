using System;
using System.Collections.Generic;
using LeetCode.WordLadders;
using LeetCode.nQueens;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //WordLadder client = new WordLadder();
            //var wordDict = new List<string>() {"ait","bit", "hot","dot","dog","lot","log","cog"};

            Console.WriteLine("Unoptimized");
            Board b = new Board(3);
            //b.PrintBoard();
            b.SolveNQueens();


            Console.WriteLine("Optimized");
            BoardOptimized bo = new BoardOptimized(3);
            
            bo.SolveNQueens();


            Console.ReadLine();
        }
    }
}
