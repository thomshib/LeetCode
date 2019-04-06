using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    public class QuickSortClass
    {

        //[left,right] both left and right are inclusive
        public void QuickSort(int[] input , int left, int right)
        {
            if (left < right) {

                //int partitionIndex = Partition(input, left, right);
                //QuickSort(input, left, partitionIndex - 1); //sort all elements less than pivot
                //QuickSort(input, partitionIndex + 1, right); //sort all element greater than pivot

                int partitionIndex = EasyPartition(input, left, right);
                QuickSort(input, left, partitionIndex - 1); //sort all elements less than pivot
                QuickSort(input, partitionIndex + 1, right); //sort all element greater than pivot
            }
        }

        private int Partition(int[] input, int left, int right)
        {
            int pivotElement = input[right];

            int indexofSmallestElement = left;

            for (int j = left; j < right; j++)
            {
                if (input[j] <= pivotElement)
                {
                    Swap(input, j, indexofSmallestElement);
                    indexofSmallestElement++;

                }
            }
            //one more swap- swap with pivot, so that pivot is in the middle

            Swap(input, indexofSmallestElement, right);

            return indexofSmallestElement;
        }


        /*
         * initialize
         * pivot = A[0] ,first element, 
         * i = 0
         * j = length
         * 
         * while (i < j)
         *  Rule 1 - increment i till we find an element greater than or equal to pivot 
         *  Rule 2 - decrement j till we find an element less than pivot
         *  Rule 3 - swap(A[i],A[j])
         * end while
         * 
         * j is the pivot position such that all element less than j are less than pivot 
         * and all elements greater than j are greater than pivot
         * swap(A[0],A[j] , put pivot element at pivot position(j)
         * 
         */
        private int EasyPartition(int[] input, int left, int right)
        {
            int pivotElement = input[left];
            int i = left;
            int j = right;

            while (true)
            {
                while (input[left] < pivotElement )
                {
                    left++;
                }

                while (input[right] > pivotElement )
                {
                    right--;
                }


                if (left < right)
                {
                    Swap(input, left, right);
                }
                else
                {
                    return right;
                }
            }
            
        }

        private void Swap(int[] input, int index, int indexofSmallestElement)
        {
            int temp = input[index];
            input[index] = input[indexofSmallestElement];
            input[indexofSmallestElement] = temp;

        }
    }
}
