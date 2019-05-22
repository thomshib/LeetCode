using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DynamicProgramming
{
    public class LongestValidParentheses
    {
        public int LongestValidParenthesis(string s)
        {
            /*
             * 
             * 
             * Scan the string from beginning to end.
            1- If current character is '(',
            push its index to the stack. If current character is ')' and the
            character at the index of the top of stack is '(', we just find a
            matching pair so pop from the stack. Otherwise, we push the index of
            ')' to the stack.

            2- stack contains 

            */

            int result = 0;
            Stack<int> stack = new Stack<int>();

            int n = s.Length;
            char LeftParenthesis = '(';
            
            int lastMismatchIdex = -1; //will remain -1 for () (()). will change if extra closing ')' is found
            for(int i = 0; i < n; i++)
            {
                //if LeftParenthessis add to stack

                if (s[i].Equals(LeftParenthesis))
                {
                    stack.Push(i);
                }else
                {
                    //right parenthesis
                    if(stack.Count > 0)
                    {
                          //found a match
                          stack.Pop();

                          //find valid string based on stack emptyness
                        if(stack.Count > 0) //there are unclosed LeftParenthesis other than the one poped
                        {
                            result = Math.Max(result, i - stack.Peek()); //valid str will start after unclosed LeftParenthesis which is still in stack
                        }
                        else
                        {
                            result = Math.Max(result, i - lastMismatchIdex); //stack is empty; so use lastMismatchIndex 
                        }
                        
                    }
                    else
                    {
                        //there is an extra RightParenthesis, preserve the last index
                        lastMismatchIdex = i;
                    }
                }
            }

            return result;


        }
    }
}
