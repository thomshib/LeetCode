using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace LeetCode.BackTracking
{
   public  class SubSet
    {
        #region subsets 
        //https://leetcode.com/explore/interview/card/facebook/53/recursion-3/278
        //https://leetcode.com/explore/interview/card/facebook/53/recursion-3/278/discuss/27281/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partitioning)
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> tempList = new List<int>();

            BackTrack(nums, result, tempList, 0);


            return result;

        }

        private void BackTrack(int[] nums, List<IList<int>> result, List<int> tempList, int start)
        {
            result.Add(new List<int>(tempList));

            for(int i = start; i < nums.Length; i++)
            {
                tempList.Add(nums[i]);
                BackTrack(nums, result, tempList, i + 1);
                tempList.RemoveAt(tempList.Count - 1); //remove the last element
            }
        }
        #endregion

        #region subsets with duplicate
        //https://leetcode.com/problems/subsets-ii/
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> tempList = new List<int>();

            if(nums.Length == 0)
            {
                return result;
            }

            DFS(nums, result, tempList,0);

            return result;
        }

        private void DFS(int[] nums, List<IList<int>> result, List<int> tempList,int start)
        {
            result.Add(new List<int>(tempList));

            for(int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1]) continue; //skip duplicates
                tempList.Add(nums[i]);
                DFS(nums, result, tempList, i + 1);
                tempList.RemoveAt(tempList.Count - 1);
            }
        }


        #endregion
    }
}
