using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DynamicProgramming
{

    //https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/304/
    //https://www.youtube.com/watch?v=mj7N8pLCJ6w
    public class BestTimetoBuyandSellStock
    {

        public int MaxProfit(int[] prices)
        {
            int min = prices[0];
                
            int result = 0;

            for(int i = 0; i < prices.Length; i++)
            {
                min = Math.Min(min, prices[i]);
                result = Math.Max(result, prices[i] - min);
                
            }

            return result;
        }
    }
}
