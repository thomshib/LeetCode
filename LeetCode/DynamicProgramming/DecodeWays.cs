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
         * Approach - pick first char and decode the rest and
         *            pick first two chars and decode the rest
         * 12345 = sum of  "a" + decode(2345) and "l" + decode(2345)  a=1 ; l=12
         * 
         * Exception case is
         * 
         * 27345 - sum of "b" + decode(2345) + nothing for two chars as 27 > 26
         * 
         * 011 is also an exception case as zero maps to nothing;
         * 
         * base case if for empty string return 1;
         * if string starts with zero return 0;
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

        private int Helper(string encodedText, int len, int?[] memo)
        {
            int result;
            if (len == 0)
            {
                return 1;
            }

            int s = encodedText.Length - len;

            if (encodedText[s] == '0') //encoding starts from 1 onwards, hence return zero
            {
                return 0;
            }

            if (memo[len] != null)
            {
                return memo[len].Value;
            }

            result = Helper(encodedText, len - 1, memo); //encoding for single digit chars

            if (len >= 2 && Convert.ToInt16(encodedText.Substring(0, 2)) <= 26) //cannot encode values for two digit chars greater than 26
            {
                result += Helper(encodedText, len - 2, memo); ////encoding for two digit chars
            }
            memo[len] = result;
            return result;
        }




        //https://www.youtube.com/watch?v=RiJBzjtVG3o
        /*
         * //base case
         * dp[0] = 1;
         * dp[1] = 1 if the char at zero index is not zero
         * 
         * recurrenence relationship;
         *  dp[i] = dp[i-1] + dp[i-2] //previous two values if first two digits are valid otherwise
         *  dp[i] = dp[i-1] //previous value only
         * 
         * 
         * 
         * 
         */
        public int DecodeWaysIterativeSolver(string encodedText)
        {
            int[] dp = new int[encodedText.Length + 1];

            dp[0] = 1; //nos of ways to decode strings of length zero
            dp[1] = encodedText[0] == '0' ? 0 : 1; // if start with '0' char return 0

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
