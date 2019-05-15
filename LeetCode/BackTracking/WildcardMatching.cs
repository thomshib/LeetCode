using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.BackTracking
{
    //http://yucoding.blogspot.com/2013/02/leetcode-question-123-wildcard-matching.html
    //https://leetcode.com/explore/interview/card/facebook/53/recursion-3/294
    public class WildcardMatching
    {
        // '?' Matches any single character.
        // '*' Matches any sequence of characters(including the empty sequence). 


        /*
         * The basic idea is to have one pointer for the string and one pointer for the pattern
         * 
         * For each element in s
                If *s==*p or *p == ? which means this is a match, then goes to next element s++ p++.
                If p=='*', this is also a match, but one or many chars may be available, so let us save this *'s position and the matched s position.
                If not match, then we check if there is a * previously showed up,
                       if there is no *,  return false;
                       if there is an *,  we set current p to the next element of *, and set current s to the next saved s position.
         * 
         * e.g.

                abed
                ?b*d**

                a == ?, s++, p++,
                e == *, save * position star=3, save s position in match = 3, p++
                e != d,  check if there was a previous *, yes, match++, s=match; p=star+1
                d == d, go on, meet the end.
                check the rest element in p, if all are *, true, else false;
         * 
         */
        public bool IsMatch(string s, string p)
        {
            int stringPosition = 0;
            int patternPosition = 0;
            int starPosition = 0;
            int matchPosition = 0;

            while(stringPosition < s.Length)
            {
                if( patternPosition < p.Length && (s[stringPosition] == p[patternPosition] || p[patternPosition] == '?'))
                {
                    stringPosition++;
                    patternPosition++;
                }else if(patternPosition < p.Length && p[patternPosition] == '*')
                {
                    starPosition = patternPosition;
                    matchPosition = stringPosition;
                    patternPosition++;

                }else if(starPosition != -1) //previously star was found
                {
                    patternPosition = starPosition + 1;
                    matchPosition++;
                    stringPosition = matchPosition;
                }
                else
                {
                    return false; //current position is not *, previous position is not *
                }


            }

            //check for remaining characters in pattern
            while (patternPosition < p.Length && p[patternPosition] == '*')
            {
                patternPosition++;
            }

            return patternPosition == p.Length;
        }
    }
}
