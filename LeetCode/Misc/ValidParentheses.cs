using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Misc
{
    //https://leetcode.com/problems/valid-parentheses/
    //https://www.youtube.com/watch?v=f8Jq8Ibg2Ys
    public class ValidParentheses
    {

        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    stack.Push(s[i]);
                }
                else if (s[i] == ')' && stack.Count > 0 && stack.Peek() == '(')
                {
                    stack.Pop();
                }
                else if (s[i] == ']' && stack.Count > 0 && stack.Peek() == '[')
                {
                    stack.Pop();
                }
                else if (s[i] == '}' && stack.Count > 0 && stack.Peek() == '{')
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }

               
            }
            return stack.Count == 0;
        }
    }
}
