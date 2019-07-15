using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Graphs
{
    public class GraphValidTree
    {
        //https://leetcode.com/problems/graph-valid-tree/

        /*
         * Approach
         *  Use Union Find Algorith preferably with weighed quick-union
         *  
         * 
         * 
         * 
         * 
         * 
         * 
         */

        public bool ValidTree(int n, int[][] edges)
        {
            WeightedQuickUnionFind qfind = new WeightedQuickUnionFind(n);
            int m = edges.GetLength(0);

            for(int i =0; i < m; i++)
            {
                int p = edges[i][0];
                int q = edges[i][1];

                //p & q in the same set then there is a cycle
                if (qfind.Find(p) == qfind.Find(q)) return false;

                qfind.Union(p, q);
            }

            if (qfind.Count() != 1) return false;

            return true;
        }
    }


    //https://www.cs.princeton.edu/~rs/AlgsDS07/01UnionFind.pdf
    public class WeightedQuickUnionFind
    {

        private int[] id; //parent link
        private int[] sz; // size of components for roots

        private int count;

        public WeightedQuickUnionFind(int n)
        {
            count = n;

            //initialize
            id = new int[n];
            for(int i = 0; i < n; i++)
            {
                id[i] = i;
            }
            sz = new int[n];
            for (int i = 0; i < n; i++)
            {
                sz[i] = 1;
            }

        }


        public int Count()
        {
            return count;
        }

        public bool Connected(int p , int q)
        {
            return Find(p) == Find(q);
        }

        public int Find(int p)
        {
            while (id[p] != p)
            {
                //path compression
                //make node point to grandparent
                id[p] = id[id[p]];
                p = id[p];
            }
            return p;
        }

        public void Union(int p , int q)
        {
            int i = Find(p);
            int j = Find(q);

            if (i == j) return;

            //make smaller root point to larger one

            if(sz[i] < sz[j])
            {
                id[i] = j;
                sz[j] += sz[i];
            }
            else
            {
                id[j] = i;
                sz[i] += sz[j];
            }
            count--;
        }
    }
}
