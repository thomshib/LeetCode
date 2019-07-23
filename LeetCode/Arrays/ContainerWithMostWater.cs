using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{

//https://leetcode.com/explore/interview/card/google/59/array-and-strings/3048/

public class ContainerWithMostWater{

    //Approach

    //https://www.youtube.com/watch?v=TI3e-17YAlc
    //two pointer solution
    public int MaxArea(int[] height) {
        int L = height.Length;
        int result = int.MinValue;
        int left = 0;
        int right = L -1;

        while(left < right){
            //find the min line for area calculation
            int min = Math.Min(height[left], height[right]);
            result = Math.Max(result, min * (right-left));

            //move the pointer which is small so that we can find a larger line

            if(height[left] < height[right]){
                left++;
            }else{
                right--;
            }

        }

        return result;
    }

}

}