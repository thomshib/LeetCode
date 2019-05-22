using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DynamicProgramming
{
    //https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/3036
    //https://www.youtube.com/watch?v=RPeTFTKwjps
    public class WordBreakSolution
    {

        #region recursive
        /*
         * break into left and right substrings and
         *  return WordBreak(LeftSubstring) && inDict(RightSubstring)
         * 
         * base case WordBreak(substring) is found in Dict
         * 
         * for e.g. WordBreak("leetcode") = inDict("LeetCode")
         *          || WordBreak("l") && inDict("eetcode")
         *          || WordBreak("le") && inDict("etcode")
         *          || WordBreak("lee") && inDict("tcode")
         *          || WordBread("leet") && inDict("code") // left part hits the base case and right part is in dict
         * 
         * 
         * 
         * 
         * 
         */
        public bool WordBreak(string s, IList<string> wordDict)
        {
            Dictionary<string, bool> memo = new Dictionary<string, bool>();
            return Helper(s, wordDict,memo);
        }

        private bool Helper(string input, IList<string> wordDict, Dictionary<string, bool> memo)
        {
            //check the memo for input
            if (memo.ContainsKey(input) )
            {
                return memo[input];
            }


            //base case
            if (wordDict.Contains(input))
            {
                memo[input] = true;
                return true;
            }
            int n = input.Length;

            for (int i = 0; i < n; i++)
            {
                string left = input.Substring(0, i + 1);
                string right = input.Substring(i + 1);

                //right condition
                if (!wordDict.Contains(right))
                {
                    continue; //c
                }

                //will reach here only if right condition is true i.e. right substring is found in dict

                //&&  left condition
               if(Helper(left, wordDict, memo)){
                    return memo[input] = true;
                    
                }
            }

            //no solution for input
            
            return memo[input] = false; 

        }

        #endregion


        #region BFS

        /**
         * https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/3036/discuss/43797/A-solution-using-BFS
         * Use a graph to represent possible solutions
         * Vertices are first chars of the words and edge represents a word
         * for e.g nightmare ; there are two ways to break it "nightmare" and "night mare". 
         * The graph would be
         *  0 --> 5 --> 9
         * 
         * check if there is a path from 0 to 9
         * Time complexity is n^2
         * Space complexity is n
         * 
         * 
         */



        public bool WordBreakBFS(string input, IList<string> wordDict)
        {
            List<int> visited = new List<int>();
            Queue<int> queue = new Queue<int>();
            int n = input.Length;
            //whole word is a vertex
            queue.Enqueue(0);

            while(queue.Count > 0)
            {
                int start = queue.Dequeue();

                if (!visited.Contains(start))
                {
                    visited.Add(start);

                    for(int i = start; i < n; i++)
                    {
                        string word = input.Substring(start, i - start + 1);

                        if (wordDict.Contains(word))
                        {
                            queue.Enqueue(i + 1);
                            if((i+1) == n)
                            {
                                return true;
                            }
                        }
                    }
                }

            }

            return false;

        }

        #endregion
    }
}
