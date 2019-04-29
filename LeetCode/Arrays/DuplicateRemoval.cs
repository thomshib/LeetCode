using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    //https://leetcode.com/problems/remove-duplicates-from-sorted-array/
    //https://www.youtube.com/watch?v=zIHe2V5Py3U
    public class DuplicateRemoval
    {

        public int RemoveDuplicates(int[] nums)
        {
            int index = 1; //first element(at index 0) is unique, hence starting replacing elements from index 1

            for(int i = 0; i < nums.Length - 1; i++)
            {
                if(nums[i] != nums[i + 1])
                {
                    nums[index++] = nums[i + 1];
                }
            }

            return index;
        }
    }
}
