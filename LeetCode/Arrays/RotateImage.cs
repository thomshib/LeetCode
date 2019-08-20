
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{

//https://leetcode.com/explore/interview/card/google/59/array-and-strings/3052/
//https://www.youtube.com/watch?v=coltu6dcol0Cb94
public class RotateImage{
     public void Rotate(int[][] matrix) {
        /*
        Approach
        //row should become col
        
        clockwise rotate
        * first reverse up to down, then swap the symmetry 
        * 1 2 3     7 8 9     7 4 1
        * 4 5 6  => 4 5 6  => 8 5 2
        * 7 8 9     1 2 3     9 6 3

        void rotate(vector<vector<int>> &matrix) {
            reverse(matrix.begin(), matrix.end());

            //swap symm
            for (int row = 0; row < matrix.size(); ++row) {
                for (int col = row + 1; col < matrix[row].size(); ++col)
                    swap(matrix[row][col], matrix[col][row]);
            }

           
        }   
        */

        Reverse(matrix);

        //swap symmetry
        int rowLength = matrix.GetLength(0);
        int colLength = matrix[0].Length;

         for (int row = 0; row < rowLength; ++row) {
                for (int col = row + 1; col < colLength; col++)
                    Swap(matrix,row,col);
            }


       
    }

        private void Swap(int[][] matrix, int row, int col)
        {
            var temp = matrix[row][col];
            matrix[row][col] = matrix[col][row];
            matrix[col][row] = temp;;
        }

        private void Reverse(int[][] matrix){

            int start = 0;
            int end = matrix.GetLength(0) - 1;

            while(start < end){
                int[] temp = matrix[start];
                matrix[start] = matrix[end];
                matrix[end] = temp;
                start++;
                end--;
            }
            
    }


}

}
