using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{

    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/289/
    //https://leetcode.com/problems/valid-palindrome-ii/discuss/119188/C++-Easy-to-Understand-Clear-Explaination

    /*
     * 
     * If they are NOT same : You now have 2 options
        2.1) Remove Left Element and Check for the Rest of String OR
        2.2) Remove Right Element and Check for the Rest of the string.
        If either of them dont give palindrome then its not a palindorme.
     * 
     * 
     * 
     * 
     */
    public class Palindrome2
    {
        public bool ValidPalindrome(string s)
        {
            int n = s.Length;

            int head = 0;
            int tail = n - 1;

            char cHead;
            char cTail;            //where there is a mismatch, extract left substring and right substring and see if the remaining is a palindrome


           while(head < tail)
            {
                cHead = char.ToLower(s[head]);
                cTail = char.ToLower(s[tail]);

                if (cHead != cTail)
                {
                    //Remove left : head + 1, tail
                    //Remove right: head, tail - 1 

                    return IsPalindrome(s, head + 1, tail) || IsPalindrome(s, head, tail - 1);
                }
                head++;
                tail--;
                
            }

            return true;
        }

        private bool IsPalindrome(string input, int left, int right)
        {
            while(left < right)
            {
                if (char.ToLower(input[left]) != char.ToLower(input[right])) return false;
                left++;
                right--;
                

            }
            return true;
        }

        private bool HelperIsPalindrome(string sub)
        {
            int n = sub.Length - 1;

            int upperDim = n / 2;

            for(int i = 0; i < upperDim; i++)
            {
                if(sub[i] != sub[n - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
