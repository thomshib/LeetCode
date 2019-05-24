using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    public class ProductofArrayExceptSelf
    {

        //https://www.youtube.com/watch?v=XQlb25LGgHE&t=1s
        /*
         *  2,3,4,5  -> output should be 60,40,30,24
         * 
         * 1,2,6,24  -> product of left side elements // consider initial element as 1
         * 
         * 60,20,5,1 -. product of right side elements
         * 
         * multiple product of left side with product of right side
         * 
         * 60,40,30,24
         */
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];


            for (int i = 0; i < n; i++)
            {
                result[i] = 1;
            }


            int left = 1;
           

            //calculate product of left side
            for(int i = 0; i < n; i++)
            {
                result[i] = result[i] * left;
                left *= nums[i];
            }


            //calculate product of right side element
            int right = 1;
            for (int i = n-1; i >=0; i--)
            {
                result[i] = result[i] * right;
                right *= nums[i];
            }

            return result;
        }
    }
}
