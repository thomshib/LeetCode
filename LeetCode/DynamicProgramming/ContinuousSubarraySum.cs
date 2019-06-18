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
         *                  
         *                  
         *                  
         *                  
         *  Easier Explanation
         *  Running sum from first element to index i : sum_i. If we mod k, it will be some format like : sum_i = k * x + modk_1
            Running sum from first element to index j : sum_j. If we mod k, it will be some format like : sum_j = k * y + modk_2
            If they have the same mod, which is modk_1 == modk_2, subtracting these two running sum
            we get the difference sum_i - sum_j = (x - y) * k = constant * k, 
            and the difference is the sum of elements between index i and j, and the value is a multiple of k.
         *                  
         *                  
         */

        public bool CheckSubarraySum(int[] nums, int k)
        {

            int n = nums.Length;
            if (n == 0) return false;

            Dictionary<int, int> map = new Dictionary<int, int>(); //sum to index mapping;

            int sum = 0;

            map[0] = -1;

            for (int i = 0; i < n; i++)
            {

                sum += nums[i];

                if (k != 0)
                {
                    sum = sum % k;
                }

                if (map.ContainsKey(sum))
                {

                    if (i - map[sum] > 1)
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

