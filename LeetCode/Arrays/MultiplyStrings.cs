using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3013

    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3013/discuss/17605/Easiest-JAVA-Solution-with-Graph-Explanation
    //https://leetcode.com/problems/multiply-strings/discuss/17651/c-easy-to-understand-clean-code
    public class MultiplyStrings
    {
        public string Multiply(string num1, string num2)
        {

            if(num1 == null || num2 == null)
            {
                return String.Empty;
            }
            int m = num1.Length;
            int n = num2.Length;

            int[] result = new int[m + n];

            for(int i = m-1; i >=0; i--)
            {
                for(int j = n-1; j >=0; j--)
                {
                    int mul = (num1[i] - '0') * (num2[j] - '0');

                    int digit_to_store_index = i + j + 1;
                    
                    while(mul > 0)
                    {
                        mul += result[digit_to_store_index];
                        result[digit_to_store_index] = mul % 10;
                        digit_to_store_index--;
                        mul = mul / 10;
                    }

                }
            }

            StringBuilder sb = new StringBuilder();
            foreach(var item in result)
            {
                if (!(sb.Length == 0 && item == 0))
                { //avoid leading zero
                    sb.Append(item);
                }
            }

            return sb.ToString();
        }
    }
}
