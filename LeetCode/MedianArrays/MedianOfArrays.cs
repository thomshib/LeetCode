using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.MedianArrays
{
    public class MedianOfArrays
    {
        //https://www.youtube.com/watch?v=LPFhl65R7ww

        //Median of two sorted Arrays of different sizes

        //Approach
        // do a binary seach on the smaller of the two array to create a partition

        //Partition the larger array so that the combined Left partition and combined right partition
        // have equal # of elements
        // Get the elements across the partition of the smaller array - maxLeftX, minRightX
        // Get the elements across the partition of the larger array - maxLeftY, minRightY
        // Calculate that the Left min element of maxLeftX <= minRightY && maxLeftY <= minRightY
        // else  move Left or move right
        

        public double FindMedianOfArrays(int[] input1, int[] input2)
        {
            int[] Xinput;
            int[] Yinput;
            if (input1.Length < input2.Length)
            {
                Xinput = input1;
                Yinput = input2;
            }
            else
            {
                Xinput = input2;
                Yinput = input1;
            }

            int x = Xinput.Length;
            int y = Yinput.Length;

            //partition the small array

            int low = 0;
            int high = x;

            while(low < high)
            {
                int partitionX = (high + low) / 2;
                //Total - partitionX
                int partitionY = (x + y + 1) / 2 - partitionX;

                //partitionX = 0 means there are no elements on the left side, Use -INF for maxLeftX
                int maxLeftX = partitionX == 0 ? int.MinValue : Xinput[partitionX - 1];
                //partitionX = x means that there are no elements on the right side, Use +INF for minRightX
                int minRightX = partitionX == x ? int.MaxValue : Xinput[partitionX];

                //partitionY = 0 means there are no elements on the left side, Use -INF for maxLeftY
                int maxLeftY = partitionY == 0 ? int.MinValue : Yinput[partitionY - 1];
                //partitionY = y means that there are no elements on the right side, Use +INF for minRightY
                int minRightY = partitionY == y ? int.MaxValue : Yinput[partitionY];

                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    //we partitioned correctly
                    if ((x + y) % 2 == 0)
                    {
                        return Convert.ToDouble((Math.Max(maxLeftY, maxLeftX) + Math.Min(minRightX, minRightY)) / 2);
                    }
                    else
                    {
                        return Convert.ToDouble(Math.Max(maxLeftY, maxLeftX));
                    } 
                }
                else if (maxLeftX > minRightY)
                {  // move to the left
                    high = partitionX - 1;
                }
                else    //move to the right
                {
                    low = partitionX + 1;
                }

            }

            throw new ArgumentException("Median not found");
        }

        

    }
}
