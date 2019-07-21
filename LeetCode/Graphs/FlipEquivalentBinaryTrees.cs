using System;
using System.Collections.Generic;
using System.Text;

namespace  LeetCodeTest.Graphs{

    public class TreeNode {
    public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }

//https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3077
public class FlipEquivalentBinaryTrees{

    public bool FlipEquiv(TreeNode root1, TreeNode root2) {
        if(root1 == null || root2 == null){
            return root1 == root2;
        }

        if(root1.val != root2.val ) return false;

        return FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right) ||  //not the OR condition
        FlipEquiv(root1.left,root2.right) && FlipEquiv(root1.right,root2.left);
    }


}

}