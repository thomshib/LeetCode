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
           

            int n = nums.Length;
            if (n == 0)
            {
                return 0;
            }



            int i = 0;
            for (int j = 1; j < n; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i + 1;

           
        }
    }
}
