using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    //https://leetcode.com/problems/move-zeroes/
    //https://www.youtube.com/watch?v=1PEncepEIoE
    //
    public class MoveZeros
    {
        public void MoveZeroesSolution(int[] nums)
        {
            int index = 0;

            for(int i =0; i < nums.Length; i++)
            {
                if(nums[i] != 0)
                {
                    nums[index++] = nums[i];
                }
            }

            //rest are all zeros from index onwards
            for(int i = index; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
    }
}
