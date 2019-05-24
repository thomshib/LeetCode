using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{

    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3012
    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3012/discuss/13867/C++-from-Wikipedia

    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3012/discuss/13872/Easiest-JAVA-Solution

    //https://www.youtube.com/watch?v=quAS1iydq7U
    //https://www.youtube.com/watch?v=zGQq3HGBTXg
    public class NextPermutationSolution
    {

        /*
         * Step-1: find the inverse point index which breaks the descending order
         * 
         * 9,1,2,4,3,1,0   - element 2 breaks the descending order, inverse index = 2
         * 
             * Step1-2: if found, find the rightmost element larger than element @ inverse point, say at index j
             *  rightmost element larger than 2, which is 3
             *  
             * Step1-3: swap elements @inverse point and @j
             *  Swap (2,3)
             *  9,1,3,4,2,1,0
             *  
             * Step1-4; reverse the array from inverse point onwards
             * 9,1,3,0,1,2,4
         * 2- if no inverse point exists; reverse the entire array
         *      0,1,3,4,2,1,9
         * 
         * 
         * 
         */
        public void NextPermutation(int[] nums)
        {
            
            if(nums == null || nums.Length <= 0)
            {
                return;
            }
            int n = nums.Length;
            int reverseIndex = n-2;

            while(reverseIndex >= 0 && nums[reverseIndex] >= nums[reverseIndex + 1]) //find element which breaks the descending order
            {
                reverseIndex--;
            }

            if(reverseIndex >= 0) //found
            {
                int indexRighmostElement = n - 1;

                while( nums[indexRighmostElement] <= nums[reverseIndex] )
                {
                    indexRighmostElement--;
                }

                Swap(nums, reverseIndex, indexRighmostElement);

                Reverse(nums, reverseIndex + 1, n - 1);
            }
            else //not found
            {
                Reverse(nums, 0, n - 1);
            }


        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        private void Reverse(int[] nums, int startIndex, int endIndex)
        {
            while(startIndex < endIndex)
            {
                Swap(nums, startIndex++, endIndex--);
            }
        }
    }
}
