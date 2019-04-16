using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DynamicProgramming
{
    //https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/264/
    //https://www.youtube.com/watch?v=qli-JCrSwuk
    public class DecodeWays
    {
        /*
         * base cases
         * 
         * input - 23456
         * case 1 Empty string
         *  return
         * 
         * case 2 (starts with zero, invalid)
         * 
         * return  
         * 
         * case 2 (single char represents a encoding)
         * 
         * '2' + '3456'
         * 
         * case 3(two char represents a encoding)
         * 
         * '23' + '456'
         * 
         * case 4 ( two char exception scenario)
         * 
         * if first two chars ? 26 then
         *  '2' + '6234'
         * 
         * 
         * 
         * 
         */


        public int DecodeWaysRecursiveSolver(string encodedText)
        {
            int?[] memo = new int?[encodedText.Length + 1];
            InitializeArray(memo, encodedText.Length + 1);
            return Helper(encodedText, encodedText.Length, memo);
        }

        private void InitializeArray(int?[] memo, int length)
        {
            for (int i = 0; i < length; i++)
            {
                memo[i] = null;
            }
        }

        private int Helper(string encodedText, int k, int?[] memo)
        {
            int result;
            if (k == 0)
            {
                return 1;
            }

            int s = encodedText.Length - k;

            if (encodedText[s] == '0') //encoding starts from 1 onwards, hence return zero
            {
                return 0;
            }

            if (memo[k] != null)
            {
                return memo[k].Value;
            }

            result = Helper(encodedText, k - 1, memo); //encoding for single digit chars

            if (k >= 2 && Convert.ToInt16(encodedText.Substring(0, 2)) <= 26) //cannot encode values for two digit chars greater than 26
            {
                result += Helper(encodedText, k - 2, memo); ////encoding for two digit chars
            }
            memo[k] = result;
            return result;
        }



        public int DecodeWaysIterativeSolver(string encodedText)
        {
            int[] dp = new int[encodedText.Length + 1];

            dp[0] = 1; //nos of ways to decode strings of length zero
            dp[1] = encodedText[0] == '0' ? 0 : 1;

            for (int i = 2; i <= encodedText.Length; i++)
            {
                int oneDigit = Convert.ToInt16(encodedText.Substring(i - 1, 1));
                int twoDigits = Convert.ToInt16(encodedText.Substring(i - 2, 2));

                if (oneDigit >= 1)
                {
                    dp[i] += dp[i - 1];
                }

                if (twoDigits >= 10 && twoDigits <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }

            return dp[encodedText.Length];
        }
    }
}
