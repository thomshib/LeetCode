using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Graphs;

namespace LeetCodeTest.Graphs
{
    

    class GraphComparer : IEqualityComparer<Node>
    {
        public bool Equals(Node x, Node y)
        {
            if (x.val == y.val)
                return true;

            return false;
        }

        public int GetHashCode(Node obj)
        {
            return obj.GetHashCode();
        }
    }
}
