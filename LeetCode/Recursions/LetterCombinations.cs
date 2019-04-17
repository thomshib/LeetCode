using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Recursions
{
    //https://leetcode.com/problems/letter-combinations-of-a-phone-number/
    public class LetterCombinations
    {
        public IList<string> LetterCombinationsSolution(string digits)
        {
            List<string> result = new List<string>();
            string[] mapping = new string[]
            {
                "0",
                "1",
                "abc",
                "def",
                "ghi",
                "jkl",
                "mno",
                "pqrs",
                "tuv",
                "wxyz"
            };


            GetCombinations(result, digits, "", 0, mapping);

            return result;

        }

        private void GetCombinations(List<string> result, string digits, string current, int index, string[] mapping)
        {
            if(index == digits.Length)
            {
                result.Add(current);
                return;
            }

            var letter = mapping[Convert.ToInt16(digits[index].ToString())];

            for(int i = 0; i < letter.Length; i++)
            {
                GetCombinations(result, digits, current + letter[i], index + 1, mapping); 
            }
        }
    }
}
