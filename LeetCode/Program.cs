using System;
using System.Collections.Generic;
using LeetCode.WordLadders;
using LeetCode.nQueens;
using LeetCode.Misc;
using LeetCode.Arrays;
using LeetCode.Strings;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //WordLadder client = new WordLadder();
            //var wordDict = new List<string>() {"ait","bit", "hot","dot","dog","lot","log","cog"};

            //Console.WriteLine("Unoptimized");
            //Board b = new Board(3);
            ////b.PrintBoard();
            //b.SolveNQueens();


            //Console.WriteLine("Optimized");
            //BoardOptimized bo = new BoardOptimized(3);

            //bo.SolveNQueens();

            // AllSubsetsOfaSet_Success();


            //var input = new int[] { 10,16,8,12,15,6,3,9,5};
            //var test = new QuickSortClass();
            //test.QuickSort(input, 0, input.Length - 1);
            //PrintArray(input);

            //Console.WriteLine($" 2nd largest element in the array: {new KLargestElement().FindKLargestElement(input, 2)}");


            string text = "xaylmz";
            string pattern = "x?y*z";
            Console.WriteLine(new WiildCardMatching().IsMatch(text, pattern));



            Console.ReadLine();
        }

        private static void PrintArray(int[] input)
        {
            for(int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
            }
        }

        public static void AllSubsetsOfaSet_Success()
        {

            var input = new int[] { 1, 2 };
            var test = new AllSubsetsOfaSet();
            //test.AllSubsets(input);
            test.IterativeHelper(input);
        }
    }
}
