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
            //https://leetcode.com/problems/course-schedule-ii/discuss/190393/Topological-Sort-Template-General-Approach!!
            // create a graph based on prerequisites
            //topological sort

            /*
             * 
             * What we need ?
                1. HashMap<Node, Indegree> inDegree: A in-degree map, which record each nodes in-degree.
                2. HashMap<Node, List<Node>children> topoMap: A topo-map which record the Node's children

                What we do ?
                1. Init: Init the two HashMaps.
                2. Build Map: Put the child into parent's list ; Increase child's in-degree by 1.
                3. Find Node with 0 in-degree: Iterate the inDegree map, find the Node has 0 inDegree. (If none, there must be a circle)
                4. Decrease the children's inDegree by 1: Decrease step3's children's inDegree by 1.
                5. Remove this Node: Remove step3's Node from inDegree. Break current iteration.
                6. Do 3-5 until inDegree is Empty: Use a while loop
             * 
            
             */


            //to take course 0 you have to first take course 1, which is expressed as a pair: [0,1] 
            //should be modeled as 1 as parent and 0 as child

            if (numCourses <= 0) return new int[0];

            //1: init map
            Dictionary<int, int> inDegree = new Dictionary<int, int>();
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for(int i =0; i < numCourses; i++)
            {
                inDegree.Add(i, 0);
                graph.Add(i, new List<int>());
            }

            //2: Build graph
            foreach(var pair in prerequisites)
            {
                int curCourse = pair[0];
                int preCourse = pair[1];

                graph[preCourse].Add(curCourse);
                inDegree[curCourse]++;

            }

            //3. find course with 0 indegree, minus one to its children's indegree, until all indegree is 0
            int[] result = new int[numCourses];
            int index = 0;
            while(inDegree.Count > 0)
            {
                bool isCycle = true;

                var keys = new List<int>(inDegree.Keys); //otherwise throws collection cannot be modified during enumarion exception
                foreach(var key in keys) //find nodes with 0 indegree
                {
                        
                    if(inDegree[key] == 0)
                    {
                        result[index] = key;
                        index++;

                        // get the node's children, and reduce their inDegree
                        List<int> children = graph[key];

                        foreach(var child in children)
                        {
                            if (inDegree.ContainsKey(child))
                            {
                                var count = inDegree[child];
                                inDegree[child] = count - 1;
                            }
                        }

                        inDegree.Remove(key); // remove the current node with 0 degree 
                        isCycle = false;


                    }
                }

                if (isCycle) //// there is a circle --> All Indegree are not 0
                {
                    return new int[0];
                }
            }

            return result;


        }
    }
}
