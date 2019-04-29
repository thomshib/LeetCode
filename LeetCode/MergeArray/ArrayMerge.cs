using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.MergeArray
{
    //https://leetcode.com/problems/merge-sorted-array/
    //http://www.learn4master.com/algorithms/leetcode-merge-sorted-array-without-extra-space

    //Given two sorted array A and array B such that A has enough void spaces in it to be able to accommodate B in it.
    //we are not allowed to create a third array. 
    //We cannot start the merge from the beginning of the two arrays, as this will require the movement of the data.

    //How about starting the merge from the end of the two arrays?

    //Suppose aL, bL records the size of elements in A and B respectively.

    //We define two indexes a = aL - 1 and b = bL - 1.We also define c = aL + bL - 1.


    //Now we compare A[a] and B[b] when b >= 0. 

    //if A[a] >= B[b], we assign A[a] to A[c], and let a and c decrease by 1.

    //If A[a] < B[b] , we assign B[b] to A[c], and let b and c decrease by 1. 

    //We also need to handle the case that the elements in the beginning of B is smaller than all the elements in A. 


    public class ArrayMerge
    {

        public void MergeArray(int[] A, int[] B)
        {
            int aDim = A.Length - 1;
            int bDim = B.Length - 1;

            MergeArray(A, B, aDim, bDim);
        }

        private void MergeArray(int[] A, int[] B, int aDim, int bDim)
        {
            int cDim = aDim + bDim - 1;

            while(bDim >= 0 && aDim >= 0)
            {
                if(A[aDim] >= B[bDim])
                {
                    A[cDim] = A[aDim];
                    aDim--;
                    cDim--;
                }
                else
                {
                    A[cDim] = B[bDim];
                    bDim--;
                    cDim--;
                }
            }

            //swap the remaining elements
            while( bDim >= 0)
            {
                A[cDim] = B[bDim];
                cDim--;
                bDim--;
            }
        }
    }
}
