using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/309/
        
    public class MergeSortedArray
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


        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;

            while( i >= 0 && j >= 0)
            {

                if(nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    k--;
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    k--;
                    j--;
                }


            }

            while (j >= 0)
            {
                nums1[k] = nums2[j];
                k--;
                j--;
            }
        }
    }
}
