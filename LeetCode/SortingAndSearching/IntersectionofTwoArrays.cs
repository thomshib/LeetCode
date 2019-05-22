using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SortingAndSearching
{
    //https://leetcode.com/explore/interview/card/facebook/54/sorting-and-searching-3/3033/
    public class IntersectionofTwoArrays
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            List<int> result = new List<int>();

            Array.Sort(nums2);

            foreach(var num in nums1)
            {
                if (BinarySearch(nums2, num))
                {
                    if (!result.Contains(num))
                    {
                        result.Add(num);
                    }
                }
            }
            return result.ToArray();
        }

        private bool BinarySearch(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while(left <= right)
            {
                int mid = left + (right - left) / 2;

                if(nums[mid] == target)
                {
                    return true;
                }else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return false;
        }
    }
}
