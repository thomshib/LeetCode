using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.WordBreak
{
    public class WordBreakSolution
    {

        public bool NaiveSolution(string text, List<string> dict)
        {
           return  NaiveSolution(text, dict, 0);
        }

        private bool NaiveSolution(string text,  List<string> dict, int startIndex)
        {
            int len = text.Length;
            
            int endIndex = 0;
            int itemLength = 0;

            if (startIndex == len)
            {
                return true;
            }

            foreach(var item in dict)
            {
                itemLength = item.Length;
                endIndex = startIndex + itemLength;

                if(endIndex > len)
                {
                    continue;
                }

                if (text.Substring(startIndex, itemLength).Equals(item))
                {
                    if(NaiveSolution(text,dict,endIndex) == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        //Dynamic Progamming
        /*
         * define an bool array T[], such that T[i] = true for zero to (i - 1) is found in dict
         * Initial state T[0] = true
         * 
         */

        public bool DynamicProgrammingSolution(string text, List<string> dict)
        {
            int len = text.Length;
            bool[] T = new bool[len +  1];
            int itemLength;
            int endIndex;
            T[0] = true; //initial state

            for(int i = 0; i < len; i++)
            {
                //continue from next match position 
                if(T[i] == false)
                {
                    continue;
                }

                foreach (var item in dict)
                {
                    itemLength = item.Length;
                    endIndex = i + itemLength;

                    if (endIndex > len)
                    {
                        continue;
                    }

                    if(T[endIndex] == true)
                    {
                        continue;
                    }

                    if (text.Substring(i, itemLength).Equals(item))
                    {
                        T[endIndex] = true;
                    }
                }
            }

            return T[len];

        }
    }
}
