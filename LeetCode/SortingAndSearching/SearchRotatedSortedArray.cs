using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SortingAndSearching
{
    public class SearchRotatedSortedArray
    {
        //https://leetcode.com/explore/interview/card/facebook/54/sorting-and-searching-3/279/

        public int Search(int[] nums, int target)
        {
            int n = nums.Length;
            int low = 0;
            int high = n - 1;

            //find index of the rotation
            
            while(low < high)
            {
                int mid = (low + high) / 2;
                if(nums[mid] >= nums[high])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }

            int rotationIndex = low; //low represents the rotation index;

            low = 0;
            high = n - 1;


            //[4,5,6,7,0,1,2]
            while (low <= high)
            {
                int mid = (low + high) / 2;
                int realMid = (mid + rotationIndex) % n; //accounting for rotation
                if(nums[realMid] == target)
                {
                    return realMid;
                }
                if (nums[realMid] > target) // 7 > 1
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }
    }
}
