using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Misc
{

    //https://www.youtube.com/watch?v=bGC2fNALbNU
    public class AllSubsetsOfaSet
    {
        public void AllSubsets(int[] array)
        {
            int?[] subset = new int?[array.Length];
            //RecursiveHelper(array, subset, 0);
            IterativeHelper(array);
        }


        // {},{0},{1},{0,1}  
        // 2 ^ n
        //https://www.geeksforgeeks.org/finding-all-subsets-of-a-given-set-in-java/
        public void IterativeHelper(int[] array)
        {
            int n = array.Length;
            //Console.WriteLine(1 << 2);
            /*  
             *  0001 << 2 = 0100(4)
             *  0010
             *  0011
             *  0100
             * 
             */
            for(int i = 0; i < (1 << n); i++)
            {
                //Console.WriteLine($"i={i}");
                /*
                 * 1<<j - sets the jth bit in 0001(1)
                 * 1 = 0001
                 * j = 0 , 1<<j,  1 << 0000 = 0001 
                 * j = 1 , 1<<j , 1 << 0001 = 0011
                 * j = 2 , 1<<j , 1 << 0010 = 0100
                 * 
                 *  i=0, j=0, loop will not run , print {}
                 *  
                 *  i=1, j=0, i & (1<<j) , 0001 & 0001 = 0001(1) , print{1}
                 *  
                 *  i=2, j=0, i & (1<<j) , 0010 & 0001 = 0000(0)
                 *  i=2, j=1, i & (1<<j) , 0010 & 0010 = 0010(0), print{2}
                 *  
                 *  i=3, j=0, i & (1<<j) , 0011 & 0001 = 0001(1)
                 *  i=3, j=1, i & (1<<j) , 0011 & 0010 = 0010(2)
                 *  i=3, j=2, i & (1<<j) , 0011 & 0100 = 0000(0) , print{1,2}
                 *  
                 *  
                 */

                Console.Write("{");
                // 1 << j , sets the jth bit to 1
                for (int j = 0; j < n; j++)
                {
                    //Console.WriteLine( $"i={i}, j={j}");
                    if((i & (1 << j)) > 0)
                    {
                        Console.Write(array[j]);
                    }
                }
                Console.Write("}");
                Console.WriteLine();
            }
        }

        public void RecursiveHelper(int[] array, int?[] subset, int index)
        {
            if (index >= array.Length)
            {
                PrintSubset(subset);
            }
            else
            {
                //two paths

                //first - index element is not included
                subset[index] = null;
                RecursiveHelper(array, subset, index + 1);


                //second - index element is included
                subset[index] = array[index];
                RecursiveHelper(array, subset, index + 1);
            }
        }

        private void PrintSubset(int?[] subset)
        {
            for (int i = 0; i < subset.Length; i++)
            {
                if (subset[i] != null)
                {
                    Console.Write(subset[i]);
                    Console.Write(",");
                }
            }
            Console.WriteLine();
        }
    }
}
