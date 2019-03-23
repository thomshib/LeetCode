using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._3sum
{

    //https://fizzbuzzed.com/top-interview-questions-1/
    public class KSum
    {

        public List<List<int>> ThreeSum(int[] nums)
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
            int j, k;

            //sort the array to avoid duplicates;
            Array.Sort(nums);

            for (int i = 0; i < len; i++)
            {
                //never let i refer to the same value twice to avoid duplicates.
                if (i != 0 && nums[i - 1] == nums[i]) continue;
                j = i + 1;
                k = len - 1;

                while(j < k)
                {
                    if(nums[i] + nums[j] + nums[k] == 0)
                    {
                        output.Add(new List<int>() { nums[i], nums[j], nums[k] });
                        j++;

                        //Never let j refer to the same value twice to avoid duplicates
                        while (j < k && nums[j] == nums[j - 1]) j++;

                    } else if(nums[i] + nums[j] + nums[k] < 0)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }

            }

            return output;
        }
    }
}
