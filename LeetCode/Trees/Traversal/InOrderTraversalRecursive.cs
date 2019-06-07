using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees.Traversal
{
    public class InOrderTraversalRecursive
    {

        public IList<int> InOrderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            Helper(root, result);

            return result;
        }

        private void Helper(TreeNode root, List<int> result)
        {
            if(root == null)
            {
                return;
            }

            Helper(root.Left, result);
            result.Add(root.val);
            Helper(root.Right, result);
        }
    }
}
