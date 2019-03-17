using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.ExtensionMethods
{
    public static class StringExtensionMethods
    {

        public static string Reverse(this string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }
    }
}
