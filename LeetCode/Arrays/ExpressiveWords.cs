

using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    //https://leetcode.com/explore/interview/card/google/59/array-and-strings/3056
    public class ExpressiveWords
    {
        public int ExpressiveWordsSolution(string input, string[] words) {
            //Approach
            /*
                input = heeellooo
                word  = helo
                
                calculate the counts of chars in both input(c1) and word(c2)
                for e.g.
                char    c1  c2
                h       1   1
                e       3   1
                l       2   1
                o       3   1

                Conditions

                1. if c1 < c2, then we can't make the ith group of word equal to the ith word of input
                     by adding characters.
                2. if c1 >= 3, then we can add letters to the ith group of word to match the ith group of input

                3. else if c1 < 3, then we must have c1 == c2 for ith group of word to match the ith group of input
            
            
            */
            int result = 0;
            var inputRLE = new RunLengthEncoding(input);
            int N = words.Length;
            bool isValid = true;

            for(int i = 0; i < N; i++){
                var wordRLE = new RunLengthEncoding(words[i]);

                //keys do not match ignore
                if(inputRLE.Key != wordRLE.Key) continue;

                int size = inputRLE.CharCount.Count;
                isValid = true;

                for(int j = 0 ; j < size; j++){
                    int c1 = inputRLE.CharCount[j];
                    int c2 = wordRLE.CharCount[j];

                    if( (c1 < c2)  || (c1 < 3 && c1 != c2) )
                    {
                        isValid = false;
                         continue;
                    }
                }
                
                if(isValid == true){
                        result++;
                } 



            }

            return result;

        }
    }

    public class RunLengthEncoding{
        string key;
        List<int> counts = new List<int>();

        public RunLengthEncoding(string input)
        {
            StringBuilder sb = new StringBuilder();

            var charSet = input.ToCharArray();
            int N = charSet.Length;
            int prev = -1;
            for(int i = 0; i < N; i++){
                if( i == N-1 || charSet[i] != charSet[i+1]){
                    sb.Append(charSet[i]);
                    counts.Add(i - prev);
                    prev = i;
                }
            }

            key = sb.ToString();
        }

        public List<int> CharCount{
            get{
                return counts;
            }
        }
         public string Key{
            get{
                return key;
            }
        }
    }
}