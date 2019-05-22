using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DynamicProgramming
{
    //https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/3034
    //https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/3034/discuss/2928/Very-simple-clean-java-solution
    public class LongestPalindrome
    {
        public string LongestPalindromeString(string s)
        {
            //for each char c in S
            // expand both left and right side of each char c
            // then expand around left and right independent of c
            //store the start and end if greater than previous iterations

            int n = s.Length;
            int left = 0;
            int right = 0;
            int start = 0;
            int end = 0;

            for(int i = 0; i < n; i++)
            {
                char current = s[i];
                left = i;
                right = i;

                //1- Expand aroud i
                while(left >= 0 && s[left].Equals(current))
                {
                    left--;
                }

                while (right < n && s[right].Equals(current))
                {
                    right++;
                }


                //2- expand around left and right

                while(left >=0 && right < n)
                {
                    if(s[left] != s[right])
                    {
                        break;
                    }
                    left--;
                    right++;
                }

                //left+1  and right-1 are the start and end index of plaindrome string
                left = left + 1;
                right = right - 1;

                if( (end - start) < (right - left) ){
                    start = left;
                    end = right;
                }

            }

            return s.Substring(start, n - end);

        }
    }
}
