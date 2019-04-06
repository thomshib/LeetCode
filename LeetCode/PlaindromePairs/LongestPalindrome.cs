using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.PlaindromePairs
{
    //find longest palindorm substring in a string
    public class LongestPalindrome
    {

        public string  NaiveSolution(string text)
        {
            int maxLength = 0;
            string longestPalindrome = String.Empty;

            int len = text.Length;

            for(int i = 0; i < len; i++)
            {
                for(int j = i + 1; j < len; j++)
                {
                    int currLength = j - i;
                    string curr = text.Substring(i, currLength);
                    if (IsPalindrome(curr)){
                        if(currLength > maxLength)
                        {
                            maxLength = currLength;
                            longestPalindrome = curr;
                        }
                    }

                }
            }

            return longestPalindrome;
        }


        //https://www.youtube.com/watch?v=nbTSfrEfo6M
        //https://www.hackerearth.com/practice/algorithms/string-algorithm/manachars-algorithm/tutorial/
        //Transform text to insert special char say '#'
        //Transformed text length is now 2 * Len + 1
        //mirror position at a node is 2*C - i

        /*Rules

            Rule - 1 : if len[mirror] > L (Left boundary)
                            P[i] = R - i (Node index)
            Rule - 2 : if len[mirror] is within L
                            P[i] = len[mirror] (copy the mirror's lenght)

            Rule - 3:  Expand beyond the min length of Rule-1 and Rule-2

        */
        public string ManacherSolutions(string text)
        {
            string T = TransformTextWithSpecialCharacters(text, '#');

            int len = T.Length;
            int[] P = new int[len];
            int C = 0;
            int R = 0;

            for(int i = 1; i < len; i++)
            {
                int mirrorIndex = 2 * C - i;

                if(i < R)
                {
                    P[i] = Math.Min(R - i, P[mirrorIndex]);
                }

                //expaning around center i
                //expand beyond the current palindrome length; as the current length is already calculated and stored in P[i]
                // d = P[i]  + 1, so the expand interval becomes
                // [i - d, i + d]

                 while( (i + (P[i] + 1) < len)  && (i - (P[i] + 1) >= 0) &&    (T[i + (P[i] +  1)] == T[i - (P[i] + 1)]) )
                 {
                    P[i]++;
                 }

                // Update C,R in case if the palindrome centered at i expands past R,
                
                if (i + P[i] > R)
                {
                    C = i;              // next center = i
                    R = i + P[i];
                }
            }


            int centerIndex = 0;
            int maxPlaindrome = 0;

            for(int i = 0; i < len; i++)
            {
                if(P[i] > maxPlaindrome)
                {
                    maxPlaindrome = P[i];
                    centerIndex = i;
                }
            }

            return text.Substring((centerIndex - 1 - maxPlaindrome) / 2, maxPlaindrome);
        }

        private string TransformTextWithSpecialCharacters(string text, char specialCharacter)
        {
            // aba becomes
            // #a#b#a# i.e 2 * text length + 1

            int len = text.Length;
            char[] charArray = new char[2 * len + 1];

            for(int i = 0; i < len; i++)
            {
                charArray[2 * i] = specialCharacter;
                charArray[2 * i + 1] = text[i];

            }

            //append special char as last element 

            charArray[charArray.Length - 1] = specialCharacter;

            return new string(charArray);
        }

        private bool IsPalindrome(string text)
        {
            int len = text.Length;
          

            for( int i = 0; i < len; i++)
            {
                //end char is (len - 1)
                // reduce i from end char
                if(text[i] != text[len - 1 - i]){
                    return false;
                }
            }

            

            return true;
        }
    }
}
