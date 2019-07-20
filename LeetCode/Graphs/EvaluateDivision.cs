using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Graphs
{

    //https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/331/
    public class EvaluateDivision
    {

        /*
         * https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/331/discuss/88169/Java-AC-Solution-using-graph
         * Approach
         * This is a graph problem
         * Imagine a/b = k as path between node a and node b with weight k. 
         * The reverse path from node b to node a is of weight 1/k.
         * Query is to find a path between two nodes
         * 
         * If a/b = 2.0 and b/c = 3.0, we can treat a,b, and c as vertices.
            then edge(a,b) weight 2.0 and edge(b,c) weight 3.0
            backward edge(b,a) weight 1/2.0 and backward edge(c,b)weight 1/3.0
            query a,c is a path from a to c, distance (a,c) = weight(a,b) * weight(b,c)
         */
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            //map from a to <b,value>
            Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();
            for(int i = 0; i < values.Length; i++)
            {
                if (!graph.ContainsKey(equations[i][0]))
                {
                    graph.Add(equations[i][0], new Dictionary<string, double>());
                }

                if (!graph.ContainsKey(equations[i][1]))
                {
                    graph.Add(equations[i][1], new Dictionary<string, double>());
                }

                graph[equations[i][0]].Add(equations[i][1], values[i]); //a to <b,value>
                graph[equations[i][1]].Add(equations[i][0], 1 / values[i]); //b to <a, 1/value>

            }

            double[] result = new double[queries.Count];

            for(int i = 0; i < queries.Count; i++)
            {
                result[i] = DFS(graph, queries[i][0], queries[i][1], 1, new HashSet<string>());
            }

            return result;
        }

        private double DFS(Dictionary<string, Dictionary<string, double>> graph, string source, string target, double seedValue, HashSet<string> visited)
        {
            if (visited.Contains(source)) return -1;
            if (!graph.ContainsKey(source)) return -1;

            visited.Add(source);

            if (source.Equals(target)) return seedValue;

            var valueMap = graph[source];
            foreach(var childKey in valueMap.Keys)
            {
                double result = DFS(graph, childKey, target, seedValue * valueMap[childKey], visited);
                if (result != -1) return result;
            }

            return -1;

        }
    }
}
