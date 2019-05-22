using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DynamicProgramming
{
    //https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/3037/

    //https://www.youtube.com/watch?v=PwDqpOMwg6U

    //https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/3037/discuss/75350/Clean-C++-Solution-and-Explaination-O(mn)-space-with-O(1)-time
    public class NumMatrix
    {

        /*
         * Approach
         * Construct a 2D array sums[row+1][col+1] extra row and extra col
         * 
         * initialize sums[0][col+1]={0} and blank column sums[row+1][0]={0}
         * 
         * sums[i+1][j+1] represents the sum of area from matrix[0][0] to matrix[i][j]
         * 
         * To calculate sum 
         * sum[i,j] = Matrix[i-1,j-1] + T[i,j-1] + T[i-1, j] - T[i-1,j-1]
         * 
         * To return the specific areas sum
         *  return 
         * 
         * sum[r2,c2] = T[r2,c2] - T[r2,c1] - T[r1,c2] + T[r1,c1]
         */
        int[][] matrix;
        public NumMatrix(int[][] matrix)
        {
            this.matrix = matrix;
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            int rowLen = matrix.GetLength(0);
            int colLen = rowLen > 0 ? matrix[0].Length :0;

            if(rowLen <=0 && colLen <=0)
            {
                return -1;
            }

            //not using a jagged array
            int[,] sums = new int[rowLen + 1,colLen + 1];

            for(int row = 1; row <= rowLen; row++)
            {
                for(int col=1; col <= colLen; col++)
                {
                    sums[row, col] = matrix[row - 1][col - 1] + sums[row, col - 1] + sums[row - 1, col] - sums[row - 1, col - 1];
                }

            }

            row1++;
            col1++;

            row2++;
            col2++;

            return sums[row2, col2] - sums[row2, col1 -1] - sums[row1 -1, col2] + sums[row1- 1, col1 - 1];

            
        }
    }
}
