using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{
    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3017/
    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/285/discuss/26808/Here-is-a-10-line-template-that-can-solve-most-'substring'-problems
    //https://www.youtube.com/watch?v=O8Cy495shf0

    public class LongestSubstringwithKDistinctCharacters
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            int[] map = new int[128]; //'a' to 'Z'

            int left = 0;
            int right = 0;
            int counter = 0;
            int n = s.Length;
            int window = 0;
                
            while(right < n)
            {
                char rightChar = s[right];
                if(map[rightChar] == 0) //char not in map
                {
                    counter++;
                }
                right++;
                map[rightChar]++;

                while(counter > k)
                {
                    char leftChar = s[left];
                    if(map[leftChar] == 1)
                    {
                        counter--;
                    }
                    left++;
                    map[leftChar]--;
                }

                window = Math.Max(window, right - left);
            }

            return window;
        }
    }
}
