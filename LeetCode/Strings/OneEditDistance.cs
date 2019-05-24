using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{
   public class OneEditDistance
    {

        //
        //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3015/discuss/50098/My-CLEAR-JAVA-solution-with-explanation

        /*
         * 
         * There're 3 possibilities to satisfy one edit distance apart: 
            * 
            * 1) Replace 1 char:
              s: a B c
              t: a D c

            * 2) Delete 1 char from s: 
              s: a D  b c
              t: a    b c

            * 3) Delete 1 char from t
              s: a   b c
              t: a D b c
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */

        public bool IsOneEditDistance(string s, string t)
        {
            int m = s.Length;
            int n = t.Length;
            int min = m > n ? n : m;

            for(int i = 0; i < min; i++)
            {
                if(s[i] != t[i])
                {
                    if (m == n)
                    { //both are of same length; hence the only possibility is replace 1 char is S & T

                        return s.Substring(i + 1).Equals(t.Substring(i + 1));
                    }else if( m > n) // S is longer than T; hence delete 1 char from S
                    {
                        return s.Substring(i + 1).Equals(t.Substring(i));
                    }
                    else // T is longer than S; hence delete 1 char from T
                    {
                        return t.Substring(i + 1).Equals(s.Substring(i));
                    }
                }
            }

            //all previous char are same;the only possibility is deleting the end char in the longer one of S and T

            return Math.Abs(n - m) == 1;
        }
    }
}
