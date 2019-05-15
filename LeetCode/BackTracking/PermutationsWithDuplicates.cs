using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.BackTracking
{
    public class PermutationsWithDuplicates
    {
        //https://leetcode.com/explore/interview/card/facebook/53/recursion-3/293/discuss/18594/Really-easy-Java-solution-much-easier-than-the-solutions-with-very-high-vote
        //https://leetcode.com/explore/interview/card/facebook/53/recursion-3/293/
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> tempList = new List<int>();

            if(nums.Length == 0)
            {
                return result;
            }
            Array.Sort(nums);

            DFS(nums, tempList, result, new bool[nums.Length]);

            return result;

        }

        /*
         * Use an extra boolean array " boolean[] used" to indicate whether the value is added to list.

            Sort the array "int[] nums" to make sure we can skip the same value.

            when a number has the same value with its previous, we can use this number only if his previous is used
       
         * 
         */

        private void DFS(int[] nums, List<int> tempList, List<IList<int>> result,bool[] used)
        {
           if(tempList.Count == nums.Length)
            {
                result.Add(new List<int>(tempList));
            }
            else
            {
                for(int i = 0; i < nums.Length; i++)
                {
                    if (used[i]) continue;
                    if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;
                    tempList.Add(nums[i]);
                    used[i] = true;
                    DFS(nums, tempList, result,used);
                    tempList.RemoveAt(tempList.Count - 1);
                    used[i] = false;
                }
            }
        }
    }
}
