using System;
using System.Collections.Generic;

namespace LeetCode.Arrays
{
    public class MissingRanges
    {

        //Approach
        /*
        1. Find the range between lower and first element in the array.
        2. Find ranges between adjacent elements in the array.
        3. Find the range between upper and last element in the array.
        
        */
    public IList<string> FindMissingRanges(int[] nums, int lower, int upper) {
        
        List<string> result  = new List<string>();
        int N = nums.Length;
        
        
        if(N == 0){
           result.Add(GetResultString(lower,upper));
           return result;
        }
             
        //Step 1 
        if(nums[0] > lower){
            result.Add(GetResultString(lower, nums[0] - 1));
        }   
         
        //Step 2
           
        for(int i = 0; i < N-1 ;i++){
            if( nums[i+1] != nums[i] && nums[i+1] > nums[i] + 1){ //one more than the previous value
                result.Add(GetResultString(nums[i] + 1, nums[i+1] - 1));
            }
        }

        //Step 3
        if(nums[N-1]  < upper){
            result.Add(GetResultString(nums[N-1] + 1, upper));
        }

            return result;

    }

        private string GetResultString(int start, int end)
        {
            return start != end ? String.Concat(start,"->", end) : start.ToString();
        }
    }
}