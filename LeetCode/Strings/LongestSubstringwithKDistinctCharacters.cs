using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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


        //Approach
        //https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/solution/
        /*
        The idea is to set both pointers in the position 0 and then move right pointer to the right
        while the window contains not more than k distinct characters. 
        If at some point we've got k + 1 distinct characters, let's move left pointer to keep 
        not more than k + 1 distinct characters in the window.

        The question is how to move the left pointer to keep only k distinct characters in the string?
        Use a  hashmap containing all characters in the sliding window as keys 
        and their rightmost positions as values. 
        At each moment, this hashmap could contain not more than k+1 elements.

        1. Return 0 if the string is empty or k is equal to zero.
        2. Set both set pointers in the beginning of the string left = 0 and right = 0 and init max substring length max_len = 1.
        3. While right pointer is less than N:
            3.1 Add the current character s[right] in the hashmap and move right pointer to the right.
            3.2 If hashmap contains k + 1 distinct characters, remove the leftmost character from the hashmap and move the left pointer so that sliding window contains again k distinct characters only.
            3.3 Update max_len.


        */   

        public int LengthOfLongestSubstringKDistinctUsingDict(string input, int k)
        {
            int N = input.Length;
            if (N < k) return N;

            //sliding window left and right pointers
            int left = 0;
            int right = 0;

            //map from Character to rightmost position
            Dictionary<char,int> map = new Dictionary<char, int>();

            int max_length = 1;

            while(right < N){

                //slide window contains less than K + 1 characters
                if(map.Count < k + 1){
                    if(!map.ContainsKey(input[right])){ //do not allow duplicates
                        map.Add(input[right], right);
                        
                    }
                    right++; //move right irrespective of duplicates
                }

                //slide windows contains  k + 1 characters

                if(map.Count == k+1){
                    //delete the left most character
                    var index = map.OrderBy(x => x.Value).First().Key; //gets ascii value of the character
                    map.Remove(index);
                    left = index + 1;
                }

                max_length = Math.Max(max_length,right - left);
            }

            return max_length;

        }
    
    }
}
