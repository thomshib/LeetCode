using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees.Traversal
{
    public class PreorderTraversalRecursive
    {
        public IList<int> PreorderTraversal(TreeNode root)
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

            result.Add(root.val);
            Helper(root.Left, result);
            Helper(root.Right, result);

        }
    }
}
