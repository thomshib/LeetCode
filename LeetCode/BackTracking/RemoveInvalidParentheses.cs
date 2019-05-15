using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.BackTracking
{
    //https://www.youtube.com/watch?v=Q-k3Ucoy6qk
    //https://leetcode.com/explore/interview/card/facebook/53/recursion-3/324/discuss/75027/Easy-Short-Concise-and-Fast-Java-DFS-3-ms-solution
    public class RemoveInvalidParenthesesSolution
    {
        public IList<string> RemoveInvalidParentheses(string s)
        {
            List<string> result = new List<string>();
            Remove(s, result, 0, 0, new char[] { '(', ')' });
            return result;

        }

        private void Remove(string s, List<string> result, int start, int lastRemovedIndex, char[] pair)
        {
            int stack = 0;
            for(int i = start; i < s.Length; i++)
            {
                if (s[i] == pair[0]) stack++;
                if (s[i] == pair[1]) stack--;

                if (stack >= 0) continue;
                //there is a mismatch, and stack is -ve
                // "()())()"
                // the j loop is for "()())"
                // j == 0 ; skip
                // j == 1; Remove the char at pos 1 i.e. (()) and append the rest of the string (); final string is (())()
                for(int j = lastRemovedIndex; j <= i; j++)
                {
                    if(s[j] == pair[1] && ( j ==  lastRemovedIndex || s[j-1] != pair[1])) //s[j-1] != pair[1] is to avoid two consecutive ')' chars
                    {
                        //extract substring upto j and extract susbstring from j+1
                        Remove(String.Concat(s.Substring(0,j), s.Substring(j + 1,s.Length - ( j + 1 ) )), result, i, j , pair);

                    }
                }
                return;

            }

            string reversedString = ReverseString(s);

            if (pair[0] == '(')
            {  //left to right has been done
                Remove(reversedString, result, 0, 0, new char[] { ')', '(' }); //do it for right to left
            }
            else //finished right to left
            {
                result.Add(reversedString);
            }

        }

        private string ReverseString(string s)
        {
            char[] cArray = s.ToCharArray();

            Array.Reverse(cArray);

            return new string(cArray);
        }
    }
}
