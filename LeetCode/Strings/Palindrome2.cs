using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{

    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/289/
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
                    // abca
                    //check both aba || aca 
                    string sub1 = String.Concat(s.Substring(0, head), s.Substring(tail, n - tail)); //aca
                    string sub2 = String.Concat(s.Substring(0, head+1), s.Substring(tail+1, n - tail - 1)); //aba
                    if (HelperIsPalindrome(sub1) || HelperIsPalindrome(sub2))
                    {
                        return true;
                    }
                }
                head++;
                tail--;
                
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
