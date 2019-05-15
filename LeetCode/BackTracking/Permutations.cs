using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.BackTracking
{
    //https://leetcode.com/explore/interview/card/facebook/53/recursion-3/292/
    //https://leetcode.com/explore/interview/card/facebook/53/recursion-3/278/discuss/27281/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partitioning)
    //
    public class Permutations
    {


        #region DFS

        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> tempList = new List<int>();
            
            if(nums.Length == 0)
            {
                return result;
            }

            DoPermute(nums, result, tempList);

            return result;
        }

        private void DoPermute(int[] nums, List<IList<int>> result, IList<int> tempList)
        {
            if (tempList.Count == nums.Length)
            {
                result.Add(new List<int>(tempList));

            }
            else
            {

                for (int i = 0; i < nums.Length; i++)
                {
                    
                    if (tempList.Contains(nums[i])) continue; //element already exists, skip


                    tempList.Add(nums[i]);
                    
                    DoPermute(nums, result, tempList);
                    
                    
                    tempList.RemoveAt(tempList.Count - 1); //remove the last element


                }
            }

        }


        //public IList<IList<int>> Permute(int[] nums)
        //{
        //    var n = nums.Length;

        //    var result = new List<IList<int>>();
        //    if (n == 0) return result;

        //    DFS(nums, new bool[n], new List<int>(), result);

        //    return result;
        //}

        private void DFS(int[] nums, bool[] isVisited, IList<int> oneResult, IList<IList<int>> result)
        {
            var n = nums.Length;

            if (oneResult.Count == n)
            {
                result.Add(new List<int>(oneResult));
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (isVisited[i]) continue;

                    oneResult.Add(nums[i]);
                    isVisited[i] = true;
                    DFS(nums, isVisited, oneResult, result);
                    isVisited[i] = false;
                    oneResult.RemoveAt(oneResult.Count - 1);
                }
            }
        }

        #endregion

        #region Swap
        /*
         * Iterate over the integers from index first to index n - 1.
                Place i-th integer first in the permutation, i.e. swap(nums[first], nums[i]).
                Proceed to create all permutations which starts from i-th integer : backtrack(first + 1).
                Now backtrack, i.e. swap(nums[first], nums[i]) back.
         * 
         * 
         * 
         * 
         * 
         * 
         */

        public IList<IList<int>> PermuteWithSwap(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();

            int n = nums.Length;
            if (nums.Length == 0)
            {
                return result;
            }

            DoPermuteWithSwap(nums, result,0,n);

            return result;
        }

        private void DoPermuteWithSwap(int[] nums, List<IList<int>> result,int first,int n)
        {
            if(first == n)
            {
                result.Add(new List<int>(nums));
            }

            for(int i = first; i < n; i++)
            {
                Swap(nums, first, i);
                DoPermuteWithSwap(nums, result, first + 1, n);
                Swap(nums, i, first);
            }
        }

        private void Swap(int[] nums, int v1, int v2)
        {
            int temp = nums[v1];
            nums[v1] = nums[v2];
            nums[v2] = temp;
        }

        #endregion
    }
}
