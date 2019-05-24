using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{

    //https://www.youtube.com/watch?v=eS6PZLjoaq8
    //https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/286/
    //https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/286/discuss/109356/JAVA-two-pointer-solution-(12ms-beat-100)-with-explaination
    public class MinimumWindowSubstring
    {

        /*
         * two pointers, left and right
         * find the pattern T in S by moving right pointer
         * Once found, try to move left pointer to find a smaller substring i.e. narrow the window
         * 
         * 
         * 
         * 
         */
        public string minWindow(string S, string T)
        {
            string result = String.Empty;
            int right = 0;
            int sLen = S.Length;
            int tLen = T.Length;
            int minLen = int.MaxValue;

            while(right < sLen)
            {
                int tIndex = 0;

                //use fast pointer to find the last char of T in S
                while (right < sLen)
                {
                    if (S[right] == T[tIndex])
                    {
                        tIndex++;
                    }

                    if (tIndex == tLen)
                    {
                        break;
                    }
                    right++;
                }
                

                //if right pointer is over the boudary

                    if(right == sLen)
                    {
                        break;
                    }


                //narrow the left window
                //use slow pointer to traverse from right to left till we find the first char of T in S
                int left = right;
                tIndex = T.Length - 1;
                while(left >= 0)
                {
                    if(S[left] == T[tIndex]){
                        tIndex--;
                    }
                    if(tIndex < 0)
                    {
                        break;
                    }
                    left--;
                }

                //if a smaller substring is found,update the result
                if(right - left + 1 < minLen)
                {
                    minLen = right - left + 1;
                    result = S.Substring(left, minLen);
                }

                // WARNING: we have to move right pointer to the next position of left pointer, NOT the next position
                // of right pointer
                right = left + 1;

            }

            return result;
        }


        /*using sliding window and hashmap
         * https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/285/discuss/26808/Here-is-a-10-line-template-that-can-solve-most-'substring'-problems
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */

        public string minWindowMap(string S, string T)
        {
            int[] map = new int[128]; // 'a' to 'Z'
            
            for(int i = 0; i < T.Length; i++)
            {
                map[T[i]]++;  //increment value for chars in T
            }

            int counter = T.Length;
            int left = 0;
            int right = 0;
            int start = -1;
            int window = int.MaxValue;

            while(right < S.Length)
            {
                char rightChar = S[right];
                right++;
                if(map[rightChar] > 0) //char matches char in T
                {
                    counter--;
                }
                map[rightChar]--;

                while (counter == 0) //valid
                { //shrink the window

                    if(right - left < window)
                    {
                        window = right - left;
                        start = left;
                    }

                    char leftChar = S[left];
                    left++;
                    if(map[leftChar] == 0) //leftChar is  in T
                    {
                        counter++; //make it invalid
                    }
                    map[leftChar]++;

                }

                
            }

            return window == int.MaxValue ? string.Empty : S.Substring(start, window);
        }


        public string MinWindow(string s, string t)
        {

            if (s == null || t == null)
            {
                return String.Empty;
            }

            int right = 0;
            int left = 0;
            int window = int.MaxValue;
            int[] map = new int[128];

            for (int i = 0; i < t.Length; i++)
            {
                map[t[i]]++;
            }

            int n = s.Length;
            int counter = t.Length;
            int start = -1;
            while (right < n)
            {

                char rightChar = s[right];
                right++;

                if (map[rightChar] > 0)
                {

                    counter--;
                }
                map[rightChar]--;

                while (counter == 0)
                {
                    char leftChar = s[left];

                    if (window > right - left)
                    {

                        window = right - left;
                        start = left;
                    }

                    if (map[leftChar] == 0)
                    {
                        counter++;
                    }

                    map[leftChar]++;
                    left++;


                }
            }

            return window == int.MaxValue ? string.Empty : s.Substring(start, window);

        }
    }
}
