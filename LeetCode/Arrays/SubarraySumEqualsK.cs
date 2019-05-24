using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{

    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3019/

    //https://www.youtube.com/watch?v=vrmcXLYRt9Y
    public class SubarraySumEqualsK
    {
        // Use a hash map to store preSum and its frequency, if map contains key of current preSum - k, then the original 
        // array must contain a subarray sum equals k 
        //SUM[i, j] == k using a brute force two loops i & j
        //but, if we compute SUM[0,i-1] and SUM[0,j], we can compute 
        //SUM[i,j] =  SUM[0,j] - SUM[0,i-1]; 
        //i.e cumulative sum - previous sum == k 
        // cumulative sum - k == previous sum
        // keep the previous sum in a map and for every iteration check if cumulative sum - k exists in map
        /*
         * {1,1,1} and K=2
         * 
         * //initialize
         * map[0,1]  //initialize;empty subarray of preSum = 0; map<sum, frequency>
         * sum = 0;
         * 
         * Repeat compute  
         *  sum += nums[i]
         *  if (sum - k) exists in map then get the frequency value from map
         *  otherwise add (sum-k) with upated frequence to map
         * loop  ; sum+=nums[i]  ; check(sum-k) exists in map            ; add/update sum to map
         * i=0   ;  0 + 1 = 1    ;    1 - 2 = -1  does not exist         ; map[1,1]  
         * i=1   ;  1 + 1 = 2    ;    2 - 2 =  0  exists with freq 1     ; map[2,1]
         * i=2   ;  2 + 1 = 3    ;    3 - 2 = 1   exists with freq 1     ; map[1,2]
         * 
         * 
         * 
         */

        public int SubarraySum(int[] nums, int k)
        {
            
            int n = nums.Length;

            if(n <= 0)
            {
                return 0;
            }
            int preSum = 0;
            int result = 0;
            Dictionary<int, int> map = new Dictionary<int, int>(); //map<sum,frequence>
            map[0] = 1; //initialize zero sum frequency to 1
            

            for(int i = 0; i < n; i++)
            {
                preSum += nums[i];

                if(map.ContainsKey(preSum - k))
                {
                    result += map[preSum - k];  //update result with frequency
                }

                //add presum to the map with updated frequency
                if (map.ContainsKey(preSum) ){
                    map[preSum]++;
                }
                else
                {
                    map[preSum] = 1;
                }
            }

            return result;
        }
    }
}
