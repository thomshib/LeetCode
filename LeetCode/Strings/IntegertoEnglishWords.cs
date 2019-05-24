using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{

    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/273
    public class IntegertoEnglishWords
    {
        private readonly string[] BELOWTEN = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};
        private readonly string[] BELOWTWENTY = {"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private readonly string[] BELOWHUNDRED = {"", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
        
    
        public string NumberToWords(int num)
        {
            if (num == 0) return "Zero";

            int i = 0;

            

            return Helper(num);
            

            
        }

        private string Helper(int num)
        {
            string result = String.Empty;

            if (num == 0)
            {
                result = String.Empty;
            }else if(num < 20)
            {
                result = BELOWTWENTY[num - 10];
            }else if(num < 100)
            {
                result = BELOWHUNDRED[num / 100] + " " + Helper(num % 10);
            }
            else if(num < 1000)
            {
                //999
                result = Helper(num / 100) + "  Hunded " + Helper(num % 100);
            }else if (num < 1000000)
            {
                result = Helper(num / 1000) + "  Thousand " + Helper(num % 1000);
            }else if (num < 1000000000)
            {
                result = Helper(num / 1000000) + "  Million " + Helper(num % 1000000);
            }
            else
            {
                result = Helper(num / 1000000000) + "  Billion " + Helper(num % 1000000000);
            }

            return result.Trim();
        }
    }
}
