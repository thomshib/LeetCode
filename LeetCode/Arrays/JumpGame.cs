using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{

    public enum Index {
    GOOD, BAD, UNKNOWN
}
public class JumpGame{

//https://leetcode.com/explore/interview/card/google/59/array-and-strings/3053/

    Index[] memo;

    public bool CanJump(int[] nums) {

        //Approach 1 - BackTrack Approach
        //return CanJumpFromPosition(0, nums);

        //Approach 2 - Dynamic Programming Top-Down
        /* 
        memo = new Index[nums.Length];
        for (int i = 0; i < memo.Length; i++) {
            memo[i] = Index.UNKNOWN;
        }
        memo[memo.Length - 1] = Index.GOOD;
        return CanJumpFromPositionDynamicPrgTopDown(0, nums);
        */

        //Approach 3: Dynamic Programming Bottom-up
        //return CanJumpFromPositionDynamicPrgBottomDown(nums);
        
        //Approach 4: Greedy
        return CanJumpFromPositionGreedy(nums);
        
    }
    #region Backtracking
        /*
        //Approach 1 - Backtrack
            This is the inefficient solution where we try every single jump pattern that takes us 
            from the first position to the last. 
            We start from the first position and jump to every index that is reachable. 
            We repeat the process until last index is reached. When stuck, backtrack.


            Complexity Analysis

            Time complexity : O(2^n) (upper bound) ways of jumping from the first position 
            to the last, where nn is the length of array nums. 

            Space complexity : O(n) 
        
        */
    private bool CanJumpFromPosition(int position, int[]nums){

        if(position == nums.Length - 1){
            return true;
        }

        int farthestJump = Math.Min(position + nums[position],nums.Length - 1);
        for(int nextPosition = position + 1;nextPosition <=farthestJump; nextPosition++ ){
            if(CanJumpFromPosition(nextPosition, nums)){
                return true;
            }
        }



        return false;

    }

    #endregion

    #region Dynamic Top down
    /*
        //Approach 2 - Dynamic Programming Top-Down

            This relies on the observation that once we determine that a certain index is good / bad, this result will never change. 
            This means that we can store the result and not need to recompute it every time.
        
            For each position in the array, we remember whether the index is good or bad. 
            Let's call this array memo and let its values be either one of: GOOD, BAD, UNKNOWN. 
            This technique is called memoization

            An example of a memoization table for input array nums = [2, 4, 2, 1, 0, 2, 0] 
            can be seen in the diagram below. 
            We write G for a GOOD position and B for a BAD one. 
            We can see that we cannot start from indices 2, 3 or 4 and eventually reach last index (6), 
            but we can do that from indices 0, 1, 5 and (trivially) 6.

            Index	0	1	2	3	4	5	6
            nums	2	4	2	1	0	2	0
            memo	G	G	B	B	B	G	G

            Steps

                1. Initially, all elements of the memo table are UNKNOWN, except for the last one, which is (trivially) GOOD (it can reach itself)

                2. Modify the backtracking algorithm such that the recursive step first checks if the index is known (GOOD / BAD)
                        2.1 If it is known then return True / False
                        2.2 Otherwise perform the backtracking steps as before

                3. Once we determine the value of the current index, we store it in the memo table

                Complexity Analysis

                    Time complexity : O(n^2)
                    For every element in the array, say i, we are looking at the next nums[i] elements 
                    to its right aiming to find a GOOD index. 
                    nums[i] can be at most n, where n is the length of array nums.

                    Space complexity : O(2n) = O(n). First n originates from recursion. Second n comes from the usage of the memo table. 
        */

        private bool CanJumpFromPositionDynamicPrgTopDown(int position, int[]nums){

        if(memo[position] != Index.UNKNOWN){
            return memo[position] == Index.GOOD ? true: false;
        }

        int farthestJump = Math.Min(position + nums[position],nums.Length - 1);
        for(int nextPosition = position + 1;nextPosition <=farthestJump; nextPosition++ ){
            if(CanJumpFromPosition(nextPosition, nums)){
                memo[position] = Index.GOOD;
                return true;
            }
        }


        memo[position] = Index.BAD;
        return false;

    }

    #endregion

    #region Dynamic BottomUp

    /*
    
    Approach 3: Dynamic Programming Bottom-up

    Top-down to bottom-up conversion is done by eliminating recursion. 
    In practice, this achieves better performance as we no longer have the method stack overhead and might even benefit from some caching. 
    More importantly, this step opens up possibilities for future optimization. 
    The recursion is usually eliminated by trying to reverse the order of the steps from the top-down approach.

    The observation to make here is that we only ever jump to the right. 
    This means that if we start from the right of the array, every time we will query a position to our right, that position has already be determined as being GOOD or BAD. This means we don't need to recurse anymore, as we will always hit the memo table.
    
    Complexity Analysis

    Time complexity : O(n^2)For every element in the array, say i, we are looking at the next nums[i] elements to its right aiming to find a GOOD index. nums[i] can be at most nn, where nn is the length of array nums.

    Space complexity : O(n)O(n). This comes from the usage of the memo table. 
    
    
    
    
     */

     private bool CanJumpFromPositionDynamicPrgBottomDown(int[] nums){
        Index[] memoArray = new Index[nums.Length];

        for (int i = 0; i < memoArray.Length; i++) {
            memoArray[i] = Index.UNKNOWN;
        }
        memoArray[memoArray.Length - 1] = Index.GOOD;

        for(int i = nums.Length - 2; i >= 0; i--){
           int farthestJump = Math.Min(i + nums[i], nums.Length -1);
           for(int j = i + 1;j <= farthestJump; j++){
               if(memoArray[j] == Index.GOOD){
                   memoArray[i] = Index.GOOD;
                   break;
               }
           }     
        }

        return memoArray[0] == Index.GOOD;


     }

     #endregion

     #region Greedy

     /*
     Approach 4: Greedy
        Once we have our code in the bottom-up state, we can make one final, important observation. From a given position, when we try to see if we can jump to a GOOD position, we only ever use one - the first one (see the break statement). In other words, the left-most one. If we keep track of this left-most GOOD position as a separate variable, we can avoid searching for it in the array. Not only that, but we can stop using the array altogether.

        Iterating right-to-left, for each position we check if there is a potential jump that reaches a GOOD index (currPosition + nums[currPosition] >= leftmostGoodIndex). If we can reach a GOOD index, then our position is itself GOOD. Also, this new GOOD position will be the new leftmost GOOD index. Iteration continues until the beginning of the array. If first position is a GOOD index then we can reach the last index from the first position.

        To illustrate this scenario, we will use the diagram below, for input array nums = [9, 4, 2, 1, 0, 2, 0]. We write G for GOOD, B for BAD and U for UNKNOWN. Let's assume we have iterated all the way to position 0 and we need to decide if index 0 is GOOD. Since index 1 was determined to be GOOD, it is enough to jump there and then be sure we can eventually reach index 6. It does not matter that nums[0] is big enough to jump all the way to the last index. All we need is one way.

        Index	0	1	2	3	4	5	6
        nums	9	4	2	1	0	2	0
        memo	U	G	B	B	B	G	G

        Complexity Analysis

        Time complexity : O(n). We are doing a single pass through the nums array, hence nn steps, where nn is the length of array nums.

        Space complexity : O(1) We are not using any extra memory.
        
     */

    private bool CanJumpFromPositionGreedy(int[] nums){
       
       int size = nums.Length - 1;
       int lastPosition = size;

       for(int currentPosition = size; currentPosition >= 0; currentPosition--){
           if(currentPosition + nums[currentPosition] >= lastPosition){
               lastPosition = currentPosition;
           }

       }

       return lastPosition == 0;
       
       
    }

    #endregion

     
}


}