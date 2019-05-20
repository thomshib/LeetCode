using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SortingAndSearching
{
    //https://leetcode.com/explore/interview/card/facebook/54/sorting-and-searching-3/308/
    //https://www.youtube.com/watch?v=S5tD47NZx7w
    public class DivideTwoIntegers
    {
        public int Divide(int dividend, int divisor)
        {
            if(dividend.Equals(int.MinValue) && divisor == -1)
            {
                return int.MaxValue;
            }
            int sign = (dividend > 0) ^ (divisor > 0) ? -1 : +1; //^ XOR operator is true when arguments differ

            int quotient = 0;

            //keep doubling the divisor and the quotient
            //15 - 3 => 1
            //15 - 6 => 2
            //15 - 12 => 4

            while(dividend >= divisor)
            {
                int temp = divisor;
                int count = 1;
                while (dividend - temp >= temp)
                {
                    temp <<= 1;
                    count <<= 1;
                }
                dividend -= temp;
                quotient += count;
            }

            return sign * quotient;
        }
    }
}
