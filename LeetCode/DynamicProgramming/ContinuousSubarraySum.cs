using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DynamicProgramming
{
    //https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/3038/
    //https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/3038/discuss/99499/Java-O(n)-time-O(k)-space
    public class ContinuousSubarraySum
    {
        /*
         * (x + y) % k = (x % k + y % k) % k
         * 
         * In short, start with mod =0, then we always do mod = (mod+nums[i])%k, if mod repeats, that means between these two mod = x occurences the sum is multiple of k.
            Math: c = a % k, c = b % k, so we have a % k = b % k.
         * 
         * (mod+nums[i])%k = (mod % k + nums[i] %k ) %k
         *                  = (k % k + 0) % k
         *                  = (1 + 0) % k
         *                  = k ; hence mod repeats
         */

        public bool CheckSubarraySum(int[] nums, int k)
        {

            Dictionary<int, int> map = new Dictionary<int, int>(); //sum to index mapping
            map[0] = -1;
            int sum = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                sum = sum % k;
                int previousIndex = -1;
                if (map.ContainsKey(sum)){
                    previousIndex = map[sum];
                }

                if(previousIndex >= 0)
                {
                    int difference = i - previousIndex;

                    if (difference >= 2)
                    {
                        return true;
                    }
                }
                else
                {
                    map[sum] = i;
                }
            }

            return false;
        }
    }
}
