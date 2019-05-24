using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{
    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3008
    public class LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            if(s == null)
            {
                return 0;
            }
            int n = s.Length;

            HashSet<char> set = new HashSet<char>();
            int start = 0;
            int result = 0;

            for(int end=0; end < n; end++)
            {
                while (set.Contains(s[end]))
                {
                    set.Remove(s[start]);
                    start++;
                }

                set.Add(s[end]);
                result = Math.Max(result, end - start + 1);

            }

            return result;
        }

        //https://www.youtube.com/watch?v=mtHelVTLKRQ
        public int LengthOfLongestSubstringSlidingWindow(string s)
        {
            if (s == null || s.Length ==0)
            {
                return 0;
            }
            int n = s.Length;

            HashSet<char> set = new HashSet<char>();
            int left = 0;
            int right = 0;
            int result = 0;

            while(right < n) { 
                if(set.Contains(s[right])) //shift window 
                {
                    set.Remove(s[left]);
                    left++;
                }
                else //expand window
                {
                    set.Add(s[right]);
                    right++;
                    result = Math.Max(result, right - left);
                }

            }

            return result;
        }
    }
}
