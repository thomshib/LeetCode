using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    public class KLargestElement
    {

        public int FindKLargestElement(int[] input, int k)
        {
            if (k >= 0 && k < input.Length)
            {
                //quicksort
                new QuickSortClass().QuickSort(input, 0, input.Length - 1);
                return input[input.Length - k];
            }
            return -1;




        }

       
    }
}
