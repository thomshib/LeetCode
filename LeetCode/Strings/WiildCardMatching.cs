using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{
    public class WiildCardMatching
    {

        //https://www.youtube.com/watch?v=3ZDZ-N0EPV0
        /*
         * //text chars is in row
         * //pattern chars in col
         * 
         * T[i][j] = T[i-1][j-1] if text[i] = pattern[i] or pattern[j] == "?" //diagonal value
         * else
         * T[i][j] = T[i-1][j] || T[i][j-1] if pattern[j] == "*" //left value or top value
         * else
         * T[i][j] = false
         * 
         * 
         */

        public bool IsMatch(string text,string pattern)
        {
            int textLength = text.Length;
            int patternLength = pattern.Length;

            
            bool[,] T = new bool[textLength + 1, patternLength + 1];
            //initializaton

            if(textLength >0 && pattern[1].Equals("*"))
            {
                T[0, 1] = true;
            }
            T[0, 0] = true; //empty chars

            int rowLength = T.GetLength(0);
            int colLength = T.GetLength(1);

            for (int i = 1; i < rowLength; i++)
            {
                for(int j = 1; j < colLength; j++)
                {
                    if(pattern[j-1].Equals('?') || (text[i-1].Equals(pattern[j-1])))
                    {
                        T[i, j] = T[i - 1, j - 1];
                    }else if (pattern[j - 1].Equals('*'))
                    {
                        T[i, j] = T[i - 1, j] || T[i, j - 1];
                    }
                    else
                    {
                        T[i, j] = false;
                    }
                }
            }

            return T[textLength, patternLength];
        }
    }
}
