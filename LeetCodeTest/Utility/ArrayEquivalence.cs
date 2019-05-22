using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Utility
{
    public static class ArrayEquivalence
    {

       public static  bool sequencesEqual(int[][] a, int[][] b)
        {
            //Check if they are the same references
            if (object.ReferenceEquals(a, b))
                return true;

            //Check if they are equall lenght
            if (a.GetLength(0) != b.GetLength(0))
                return false;

            ////Check if they are equall lenght
            //if (a.GetLength(1) != b.GetLength(1))
            //    return false;

            //force check if all the values are the same, return on first dissimilarity

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (a[i][j] != b[i][j])
                        return false;
                   
                }
            }
           

            //They survived the previous check, so they must be equal
            return true;
        }


        public static bool sequencesEqual(int[] a, int[] b)
        {
            //Check if they are the same references
            if (object.ReferenceEquals(a, b))
                return true;

            //Check if they are equall lenght
            if (a.Length != b.Length)
                return false;

            Array.Sort(a);
            Array.Sort(b);
           

            //force check if all the values are the same, return on first dissimilarity

            for (int i = 0; i < a.Length; i++)
            {
                
                    if (a[i] != b[i])
                        return false;

               
            }


            //They survived the previous check, so they must be equal
            return true;
        }
    }
}
