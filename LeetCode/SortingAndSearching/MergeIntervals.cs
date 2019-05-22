using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SortingAndSearching
{
    //https://leetcode.com/explore/interview/card/facebook/54/sorting-and-searching-3/310/
    //https://leetcode.com/explore/interview/card/facebook/54/sorting-and-searching-3/310/discuss/21222/A-simple-Java-solution

    public class MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {

            if (intervals.GetLength(0) <= 0)
            {
                return intervals;
            }


            //sort intervals by start time
            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            List<int[]> result = new List<int[]>();

            int start = intervals[0][0];
            int end = intervals[0][1];

            foreach (var interval in intervals)
            {
                if (interval[0] <= end)
                { //Overlapping interval
                    end = Math.Max(end, interval[1]);
                }
                else
                {
                    //non- overlapping intervals, add the previous values and reset bound;
                    result.Add(new int[] { start, end });
                    start = interval[0];
                    end = interval[1];
                }
            }

            //Add the last interval
            result.Add(new int[] { start, end });

            return result.ToArray();
        }
    }
}