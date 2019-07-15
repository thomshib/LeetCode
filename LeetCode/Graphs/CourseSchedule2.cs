using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Graphs
{

    //https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3070/
    public class CourseSchedule2
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            //Approach
            // create a graph based on prerequisites
            //traverse using BFS 


            //to take course 0 you have to first take course 1, which is expressed as a pair: [0,1] 
            //should be modeled as 1 as parent and 0 as child

        }
    }
}
