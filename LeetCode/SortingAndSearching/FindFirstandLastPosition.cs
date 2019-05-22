using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SortingAndSearching
{

    //https://leetcode.com/explore/interview/card/facebook/54/sorting-and-searching-3/3030/
    public class FindFirstandLastPosition
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int n = nums.Length;

            
            int low = 0;
            int high = n - 1;
            
            while(low <= high)
            {
                int mid = (low + high) / 2;

                if(nums[mid] == target)
                {

                    return FindRange(nums, mid);

                }
                else if( nums[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }

            }

            return new int[] { -1, -1 };


        }




        public int[] FindRange(int[] nums, int index)
        {

            int start = index;
            while(start >= 0 && nums[start] == nums[start - 1])
            {
                start--;
            }

            int end = index;

            while (end < nums.Length && nums[end] == nums[end + 1])
            {
                end++;
            }

            return new int[] { start, end };
        }
    }
}
