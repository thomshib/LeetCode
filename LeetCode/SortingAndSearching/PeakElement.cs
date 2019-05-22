using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SortingAndSearching
{
    public class PeakElement
    {
        //https://leetcode.com/explore/interview/card/facebook/54/sorting-and-searching-3/3032
        //https://courses.csail.mit.edu/6.006/spring11/lectures/lec02.pdf
        public int FindPeakElement(int[] nums)
        {
            int n = nums.Length;
            if( n <= 0)
            {
                return -1;
            }

            int low = 0;
            int high = n - 1;

            while(low < high)
            {
                int mid = low + (high - low) / 2;

                if(nums[mid-1] <= nums[mid] && nums[mid] >= nums[mid + 1])
                {
                    return mid;
                }else if (nums[mid - 1] > nums[mid])
                {
                    high = mid - 1;
                }else if(nums[mid] < nums[mid + 1])
                {
                    low = mid + 1;
                }
            }

            return -1;

        }
    }
}
