using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SortingAndSearching
{
    //https://leetcode.com/explore/interview/card/facebook/54/sorting-and-searching-3/3031/
    public class Power
    {
        public double Pow(double x, int n)
        {
            //naive solution x * result(x, n-1)

            if( n == 0)
            {
                return 1;
            }

            if(n < 0)
            {
                n = -n;
                x = 1 / x;
            }

            return (n % 2 == 0) ? Pow(x * x, n / 2) : x * Pow(x * x, n / 2);

        }
    }
}
