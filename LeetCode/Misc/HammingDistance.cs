using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Misc
{
    //https://leetcode.com/problems/hamming-distance/
    //https://www.youtube.com/watch?v=oGU1At1GFvc
    public class HammingDistances
    {
        public int HammingDistance(int x, int y)
        {
            int result = 0;

            while( x > 0 || y > 0)
            {
                result += (x % 2) ^ (y % 2);  //modulo will get 1 for odd# and 0 to even#

                x = x >> 1;  //equivalent to divide by 2
                y = y >> 1;
            }


            return result;
        }
    }
}
