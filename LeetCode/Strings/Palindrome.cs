using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{
    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/288/

    
    public class Palindrome
    {
        public bool IsPalindrome(string s)
        {
            

            int n = s.Length;

            int head = 0;
            int tail = n - 1;

            char cHead;
            char cTail;

            while(head < tail)
            {
                cHead = char.ToLower(s[head]);
                cTail = char.ToLower(s[tail]);

                if (!char.IsLetterOrDigit(cHead))
                {
                    head++;
                }
                else if (!char.IsLetterOrDigit(cTail))
                {
                    tail--;
                }
                else
                {

                    if (cHead != cTail)
                    {
                        return false;
                    }
                    head++;
                    tail--;
                }

            }

            return true;
           

        }
    }
}
