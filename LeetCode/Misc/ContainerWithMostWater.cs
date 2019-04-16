using System;
using System.Collections.Generic;
using System.Text;


//https://leetcode.com/problems/container-with-most-water/
//https://leetcode.com/problems/container-with-most-water/discuss/272964/O(n)-Solutions-Beats-98.43-in-Runtime-and-99.86-in-Memory-Usage-respectively.
namespace LeetCode.Misc
{
    public class ContainerWithMostWater
    {

        public int MaxArea(int[] height)
        {
            int len = height.Length;
            int maxArea = int.MinValue;

            int left = 0;
            int right = len - 1;

            while(left< right)
            {
                int minHeight = Math.Min(height[left], height[right]);
                int xAxisLengtth = right - left;
                int calculatedArea = minHeight * xAxisLengtth;

                maxArea = Math.Max(maxArea, calculatedArea);

                if(height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }

            }

            return maxArea;
        }
    }
}
