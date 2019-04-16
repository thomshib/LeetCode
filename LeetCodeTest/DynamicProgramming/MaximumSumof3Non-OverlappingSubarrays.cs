using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.DynamicProgramming
{
    //https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/287/discuss/108231/C++Java-DP-with-explanation-O(n)
    public class MaximumSumof3Non_OverlappingSubarrays
    {
        /**
         * High level: calculate left local max subarray with size k from left to right and right local max subarray
         * with size k from right to left. And use sliding window to do 3-sum from left to right
         *
         * Step 1: calculate prefix sum dp array
         * Step 2: calculate left local max subarray with size k
         * dp1: leftMaxPos[i] represents max subarray STARTING index with size k starting from i in the range [0, i - k]
         * dp2: rightMaxPos[i] represents max subarray STARTING index with siz k starting from i in the range [i, n - 1]
         *
         * Step 3: traverse from k to n - 2k, keep a window with size k, calculate "3sum" in every iteration, and return
         * the max one.
         * eg: for index i, we have max subarray starting index (leftMaxPos[i - 1]) on the left side of current window,
         * we also have max subarray starting index (rightMaxPos[i + k]) on the right side of current window. Then we are
         * able to find max 3sum by traversing all possible 3sums
     **/

        public int[] maxSumOfThreeSubarrays(int[] nums, int k)
        {
            int[] results = new int[3];
            if (nums == null || nums.Length == 0 || k == 0)
            {
                return results;
            }

            int n = nums.Length;
            int[] preSum = new int[n];

            // preSum array saves prefix sum include current index
            preSum[0] = nums[0];
            for (int i = 1; i < n; i++)
            {
                preSum[i] = preSum[i - 1] + nums[i];
            }

            //intervals
            //left interval is 0 to K-1  i.e [0,k-1]
            //middle interval is k to (n - 2k) i.e  [k,(n - 2k)]
            //right interval is n - 2k + 1 to n - k i.e. [(n - 2k + 1) , (n-k)]

            // leftPosMax[i] saves the STARTING index of max partial sum with length k for the left interval in range [0, i]
            // leftPosMax[i] means if the middle interval start index is i, what's the index for left interval 
            // such that left interval has the maximum sum.
            // initial value is 0 because if middle interval start index is k, then left interval start index is 0.

            // middle interval start index can only be k, k + 1, ... , n - 2*k and we start from k + 1 


            // rightPosMax[i] saves the STARTING index max partial sum with length k for the right interval in range [i, n-1]
            // rightPosMax[i] means if the middle interval start index is i, what's the index for right interval 
            // such that right interval has the maximum sum.

            int[] leftMaxPos = new int[n], rightMaxPos = new int[n];

            // traverse from k to right, dynamically calculate starting index of max k sum in previous ith items
            
            int partialMax = preSum[k - 1];
            for (int i = k; i < n; i++)
            {
                int curLeftKSum = preSum[i] - preSum[i - k];
                if (curLeftKSum > partialMax)
                {
                    leftMaxPos[i] = i - k + 1; // if left interval start index is i - k, the sum of the left interval is bigger.
                    partialMax = curLeftKSum;
                }
                else
                {
                    leftMaxPos[i] = leftMaxPos[i - 1];
                }
            }


            //traverse from right - k + 1 to left, dynamically calculate starting index of max k sum in last ith items
            // initial value is n-k because if middle interval start index is n - 2*k, then right interval start index is n-k.
            // middle interval start index can only be n - 2 * k, n - 2 * k - 1, ... , k and we start from n -2 * k - 1

            partialMax = 0;
            for (int i = n - k; i >= 0; i--)
            {
                // WARNING: in order to avoid array out of bound error, we cannot use preSum[i+k-1] - preSum[i-1]
                int curRightKSum = preSum[i + k - 1] - preSum[i] + nums[i];

                // WARNING: in order to get lexicographical order, when there are two intervals with equal max sum, always 
                // select the left most one. So we use ">=" if we traverse from right to left (if equal, select left one)
                // If traverse from left to right, just use ">" in the if-statement, since we do not need to replace the
                // right one if we find another equal value from the right part.

                if (curRightKSum >= partialMax)
                {
                    rightMaxPos[i] = i;
                    partialMax = curRightKSum;
                }
                else
                {
                    rightMaxPos[i] = rightMaxPos[i + 1];
                }
            }

            //traverse from k to n - 2k, dynamically calculate max 3 sum with leftPart + middlePart + rightPart
            //middle range is from [k, n-2*K]
            int maxSum = 0;
            for (int i = k; i <= n - 2 * k; i++)
            {
                //saves current left max index and current right max index in current ith position
                int curLeftMaxPos = leftMaxPos[i - 1], curRightMaxPos = rightMaxPos[i + k];

                //calculate current max 3 sum (left + middle + right)
                //for the left part, be careful the error of array out of bound (use ... + nums[curLeftMaxPos])
                int cur3Sum = (preSum[curLeftMaxPos + k - 1] - preSum[curLeftMaxPos] + nums[curLeftMaxPos])
                            + (preSum[i + k - 1] - preSum[i - 1])
                            + (preSum[curRightMaxPos + k - 1] - preSum[curRightMaxPos - 1]);



                //if current 3 sum is greater than previous max sum, update max sum value and results array
                if (cur3Sum > maxSum)
                {
                    maxSum = cur3Sum;
                    results[0] = curLeftMaxPos;
                    results[1] = i;
                    results[2] = curRightMaxPos;
                }
            }
            return results;
        }



    }
}
