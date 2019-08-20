using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace LeetCode.Others
{


public class MaxPointsOnLine{

    //https://leetcode.com/problems/max-points-on-a-line/

    /*
    Approach:
    slope = rise / run = (y2-y1) / (x2 - x1) 
    1. Initiate the maximum number of points max_count = 1.
    2. Iterate over all points i from 0 to N - 2.
        2.1 For each point i find a maximum number of points max_count_i on a line passing through the point i :

            2.1.1 Initiate the maximum number of points on a line passing through the point i : count = 1.

            2.1.2 Iterate over next points j from i + 1 to N - 1.
                    If j is a duplicate of i, update a number of duplicates for point i.
                    If not:
                        Save the line passing through the points i and j.
                        Update count at each step.

            2.1.3 Return max_count_i = count + duplicates.

        2.2 Update the result max_count = max(max_count, max_count_i)
    
    
    */
    Point[] points;
    int N;

    Dictionary<double,int> lines = new Dictionary<double, int>();
    int horizontal_lines;

    public int MaxPoints(int[][] pointsArray) {

        N = pointsArray.GetLength(0);

        // If the number of points is less than 3
        // they are all on the same line.
        if(N < 3) return N;

        points = new Point[N];
        for(int i = 0 ;i < N; i++){
            
            points[i] = new Point(pointsArray[i][0],pointsArray[i][1]);
            
        }

        int maxResult = 1;
        for(int i = 0;i < N-1; i++){
            maxResult = Math.Max(MaxPointsOnLineContainingPointI(i),maxResult);
         }

         return maxResult;

        
    }

    private (int,int) AddLine(int i, int j, int count, int duplicates){
        /*
            Add a line passing through i and j points.
            Update max number of points on a line containing point i.
            Update a number of duplicates of i point.
        */

        //rewrite point as coordinates
        int x1 = points[i].X;
        int y1 = points[i].Y;
        int x2 = points[j].X;
        int y2 = points[j].Y;

        //add a duplicate
        if( (x1 == x2) && (y1 == y2)){
            duplicates++;
        }else if ( y1 == y2){
            horizontal_lines++;
            count = Math.Max(horizontal_lines, count);

        }else{
            //calculate slope
            double slope;
            if( (x2-x1) != 0){
                slope = (y2-y1) / (x2-x1);
            } else{
                slope = y2-y1;  //avoid divide by zero exception
            }
            
            if(!lines.ContainsKey(slope)){
                lines.Add(slope,1);     //initialized to one to accomodate for two points
            }
            lines[slope]++;
            count = Math.Max(lines[slope], count);
        }

        return (count,duplicates);

    }

    private int MaxPointsOnLineContainingPointI(int i){
    /*
        Compute the max number of points
        for a line containing point i.
    */
        // init lines passing through point i
        lines.Clear();
        horizontal_lines = 1;

        // One starts with just one point on a line : point i.
        int count = 1;

        //There are no duplicates so far
        int duplicates = 0;

        // Compute lines passing through point i (fixed)
        // and point j (interation).
        // Update in a loop the number of points on a line
        // and the number of duplicates of point i.

        for(int j = i + 1 ; j < N; j++){
            (count,duplicates) =  AddLine(i,j, count, duplicates);

        }

        return count + duplicates;


    }



}
}