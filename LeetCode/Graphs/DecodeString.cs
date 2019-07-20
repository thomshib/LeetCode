using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Graphs
{

    //https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3073/
    //https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3073/discuss/87534/Simple-Java-Solution-using-Stack
    public class DecodeStringSolution
    {
        public string DecodeString(string s)
        {
            if (s == null || s.Length == 0) return s;

            int L = s.Length;
            Stack<int> countStack = new Stack<int>();
            Stack<StringBuilder> resultStack = new Stack<StringBuilder>();
            char[] charSet = s.ToCharArray();
            int count = 0;
            

            StringBuilder current = new StringBuilder();
            foreach (var character in charSet)
            {
                //get repeat number
                if (char.IsDigit(character))
                {
                    count = count * 10 + (character - '0');
                }else if(character == '['){

                    //push previous decoded string on stack
                    countStack.Push(count);
                    resultStack.Push(current);

                    //reset current values
                    current = new StringBuilder();
                    count = 0;
                }else if(character  == ']')
                {
                    //start to decode current string
                    int repeat = countStack.Pop();
                    StringBuilder tmp = current;

                    current = resultStack.Pop();
                    for(int j = 0; j < repeat; j++)
                    {
                        current.Append(tmp);
                    }

                    
                }
                else
                {
                    //normal char,concat to current string
                    current.Append(character);
                }

            }

            return current.ToString();
        }
    }
}
