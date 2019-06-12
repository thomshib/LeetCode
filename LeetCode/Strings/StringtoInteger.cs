using System ;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{
    public class StringtoInteger
    {
        //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3009/
        //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3009/discuss/4654/My-simple-solution?page=2

        public int MyAtoi(string str)
        {
            /**
             *  case-1: "123" => 123
             *  case-2: "  12 3" => 123
             *  case-3: "123*!123" => 123
             *  case-4: "+123" => 123
             *  case-5: "-123" => -123
             *  case-6: "-91283472332" => Int.min
             *  case-7: "91283472332" => Int.max
             * 
             * 
             **/

            int sign = 1;
            int index = 0;
            int result = 0;
            int n = str.Length;

            if (str == null || n == 0)
            {
                return 0;
            }

            while (index < n && str[index] == ' ')
            {
                index++;
            }

            if(index < n && ( str[index] == '-' || str[index] == '+') )
            {
                sign = 1 - 2 * Convert.ToInt16(str[index++] == '-');
            }

            while(index < n && str[index] >= '0' && str[index] <= '9')
            {
                /*
                 * The value of INT_MAX is +2147483647.
                    So, when base == INT_MAX / 10 , i.e. base = +214748364.
                    if we do, base = 10 * base + (str[i++] - '0'); we can have str[i] to be max as 7.
                    If str[i] ==5, then
                    base = 214748364*10 + 5 = 2147483645 < INT_MAX
                 * 
                 * 
                 */
                if ( (result > int.MaxValue / 10) || (result == int.MaxValue / 10 && (str[index] - '0') > 7))
                {
                    if (sign == 1)
                    {
                        return int.MaxValue;
                    }
                    else
                    {
                        return int.MinValue;
                    }
                }

                result = result * 10 + str[index++] - '0';
            }

            return sign * result;
        }
    }
}
