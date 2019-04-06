using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._3sum
{

    //https://fizzbuzzed.com/top-interview-questions-1/
    public class KSum
    {

        /*
         *Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0?
         *Find all unique triplets in the array which gives the sum of zero.
         *Note: Elements in a triplet (a,b,c) must be in non-descending order. (ie, a  b  c)
         *The solution set must not contain duplicate triplets. 
         * 
         */
        public List<List<int>> ThreeSumNaive(int[] nums)
        {
            int len = nums.Length;
            List<List<int>> output = new List<List<int>>();

            for(int i=0; i < len; i++)
            {
                for(int j = i+1; j <len; j++)
                {
                    for(int k = j+1; k < len; k++)
                    {
                        if (nums[i] + nums[j] +  nums[k] == 0)
                        {
                            output.Add(new List<int>() { nums[i], nums[j], nums[k] });
                        }
                    }
                }
            }

            return output;
        }

        public List<List<int>> ThreeSumWithTwoPointers(int[] nums)
        {
            int len = nums.Length;
            List<List<int>> output = new List<List<int>>();
            int left, right;

            //sort the array to avoid duplicates;
            Array.Sort(nums);

            for (int index = 0; index < len; index++)
            {
                //never let index refer to the same value twice to avoid duplicates.
                if (index != 0 && nums[index - 1] == nums[index]) continue;

                left = index + 1;
                right = len - 1;

                while(left < right)
                {
                    if(nums[index] + nums[left] + nums[right] == 0)
                    {
                        output.Add(new List<int>() { nums[index], nums[left], nums[right] });
                        left++;

                        //Never let left refer to the same value twice to avoid duplicates
                        while (left < right && nums[left] == nums[left - 1]) left++;

                    } else if(nums[index] + nums[left] + nums[right] < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }

            }

            return output;
        }

        public List<List<int>> TwoSumWithHashMap(int[] input,int target)
        {
            List<List<int>> output = new List<List<int>>();
            Dictionary<int, int> map = new Dictionary<int, int>();
            int len = input.Length;

            for(int i = 0; i < len; i++)
            {
                if (map.ContainsKey(input[i])){
                    output.Add(new List<int>() { map[input[i]], i });
                    
                }
                else
                {
                    map.Add(target - input[i], i); 
                }
            }

            return output;
        }

        public List<List<int>> TwoSumWithSortedInputArray(int[] input, int target)
        {
            List<List<int>> output = new List<List<int>>();
            Array.Sort(input);

            int len = input.Length;
            int left = 0;
            int right = len - 1;

            int sum = 0;

            while(left< right)
            {
                sum = input[left] + input[right];

                if(sum < target)
                {
                    left++;
                }else if(sum > target)
                {
                    right--;
                }
                else
                {
                    output.Add(new List<int>() { left, right });
                }
            }


            return output;
        }
    }
}
