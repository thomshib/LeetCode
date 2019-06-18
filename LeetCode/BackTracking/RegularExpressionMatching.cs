using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.BackTracking
{
    //https://leetcode.com/explore/interview/card/facebook/53/recursion-3/307
    //https://www.youtube.com/watch?v=l3hda49XcDE
    //https://blog.baozitraining.org/2019/04/leetcode-solution-10-regular-expression.html

    public class RegularExpressionMatching
    {
        /*
         * create a boolean 2 dim arrray of rowLenght+1, colLength+1; rows are string, cols are pattern
         * dot = "."
         * star ="*"
         *  Case 1 : current values match, hence check whether previous values match
         *  T[i][j] = T[i-1][j-1] if s[i] == p[j] || p[j] == dot
         * 
         *  
         *  Case 2 - if pattern[j] == star
         *  T[i][j] = T[i][j-2] for 0 occurence; j is *, j-1 is a char; hence j-2
         *  OR 
         *  T[i][j] = T[i-1][j] if s[i] == p[j-1] || p[j-1] == dot   for 1 or more occurence
         * 
         */
        public bool IsMatch(string text, string pattern)
        {
            int row = text.Length;
            int col = pattern.Length;

            if (row == 0 && col == 0)
            {
                return true;
            }
            else if (col == 0 || row == 0)
            {
                return false;
            }

            bool[,] T = new bool[row + 1, col + 1];

            char dot = '.';
            char star = '*';

            

            //initialization
            T[0, 0] = true;

            //deals with pattern like a* or a*b*

            for (int j = 1; j <= col; j++)
            {
                if (pattern[j - 1].Equals(star))
                {
                    if (T[0, j - 1])
                    {
                        T[0, j] = true;
                    }
                    else if (j >= 2 && T[0, j - 2])
                    {
                        T[0, j] = true;
                    }
                }
            }

            for(int i = 1; i <=row; i++)
            {
                for(int j = 1; j <= col; j++)
                {


                    if (pattern[j - 1].Equals(dot) || pattern[j - 1] == text[i - 1]) //Case-1
                    {
                        T[i, j] = T[i - 1, j - 1];
                    } else if (pattern[j - 1].Equals(star)){     //Case-2

                        T[i, j] = T[i, j - 2];
                        if(pattern[j-2].Equals(dot) || pattern[j-2] == text[i-1])
                        {
                            T[i, j] = T[i, j] || T[i - 1, j];
                        }
                    }
                    else
                    {
                        T[i,j] = false;
                    }
                }


            }

            return T[row, col];

        }
    }
}

