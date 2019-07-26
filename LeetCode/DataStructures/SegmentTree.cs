using System;
using System.Collections.Generic;
using System.Text;
namespace LeetCode.DataStructures{
    
    //https://leetcode.com/articles/a-recursive-approach-to-segment-trees-range-sum-queries-lazy-propagation/

    /*

        Read O(log(N))
        Update O(log(N))
        
        The node of the tree is at index 00. Thus tree[0] is the root of our tree.
        The children of tree[i] are stored at tree[2*i+1] and tree[2*i+2]
    */
        public class SegmentTree{
            int[] tree;
            int[] lazy;
            int n;

            public SegmentTree(int[]  input)
            {
                int n = input.Length;

                ////The max size of this array is about 2 * 2 ^ log2(n) + 1 which is appro 4N
                tree = new int[4 * n]; 
                lazy = new int[4 * n];

                
                BuildSegmentTree(input,0, 0, n - 1);
                
            }

            private void BuildSegmentTree(int[] array, int treeIndex, int low, int high){

                    if(low == high){ //leaf node
                        tree[treeIndex]  = array[low];
                        return;

                    } 

                    int mid = low + (high - low) / 2;

                    //recurse deeper for children
                    BuildSegmentTree(array,2 * treeIndex + 1, low, mid); //left child
                    BuildSegmentTree(array,2 * treeIndex + 2, mid + 1, high);  //right child

                    //merge the build results
                    tree[treeIndex] = MergeFunction(tree[2*treeIndex + 1], tree[2*treeIndex + 2]);




            }

            //the merge function is sum, it could be anything else like min, max etc

            private int MergeFunction(int leftChildValue, int rightChildValue){

                return leftChildValue + rightChildValue;
            }


            //Query an interval/segment of data

            //query for arr[i..j]

            /*
                // call this method as querySegTree(0, 0, n-1, i, j);
                // Here [i,j] is the range/interval you are querying.
                // This method relies on "null" nodes being equivalent to storing zero.            
            
            */
            public int QuerySegmentTree(int treeIndex, int low, int high, int rangeStart, int rangeEnd){

                //scenario 1; segment outside range

                if(low > rangeEnd || high < rangeStart){
                    return 0;   //represents a null node
                }

                //scenario 2; segment completely inside range

                if( low >= rangeStart && high <= rangeEnd){
                    return tree[treeIndex];
                }

                //scenario 3; partial overlap; Recurse deeper

                int mid = low + (high-low) / 2;

                if(rangeStart > mid){
                    return QuerySegmentTree(2 * treeIndex + 2, mid+1,high,rangeStart,rangeEnd);
                }else if(rangeEnd <= mid){
                    return QuerySegmentTree(2 * treeIndex + 1, low, mid, rangeStart, rangeEnd);
                }

                int leftQuery = QuerySegmentTree(2*treeIndex + 1,low, mid, rangeStart, mid);
                int rightQuery = QuerySegmentTree(2*treeIndex + 2,mid + 1, high, mid + 1, rangeEnd );

                //merge query result
                return MergeFunction(leftQuery, rightQuery);

            }

            //Update the value of an element.


            /*
                // call this method as updateValSegTree(0, 0, n-1, i, val);
                // Here you want to update the value at index i with value val.
            
            
            */

            // low and high are starting and ending indexes which a node is resposible for
            public void UpdateSegmentTree(int treeIndex, int low, int high, int arrayIndex, int value){

                if(low == high){ //leaf node
                        tree[treeIndex]  = value;
                        return;

                } 

                 int mid = low + (high - low) / 2;

                    //recurse deeper for children
                    if(arrayIndex > mid){
                        UpdateSegmentTree(2 * treeIndex + 2, mid + 1 , high, arrayIndex, value); //right child

                    }else if( arrayIndex <= mid){
                         UpdateSegmentTree(2 * treeIndex + 1,low,  mid, arrayIndex, value);
                    }

                    //merge the update results
                    tree[treeIndex] = MergeFunction(tree[2*treeIndex + 1], tree[2*treeIndex + 2]);
            }


            #region lazy propagation

            /*
            
             Update parent nodes with value  
             and postpone updates to its children by storing this update information in separate nodes called lazy nodes.

             lazy[] which is the same size as  segment tree array tree[]
             lazy[i] holds the amount by which the node tree[i] needs to be incremented, when that node is finally accessed or queried. 
             When lazy[i] is zero, it means that node tree[i] is not lazy and has no pending updates.
            
            */

            /*
            
                Updating a range lazily

                This is a three step process:

                    1. Normalize the current node. This is done by removing laziness. 
                    We simple increment the current node by appropriate amount to remove it's laziness. 
                    Then we mark its children to be lazy as the descendants haven't been processed yet.

                    2. Apply the current update operation to the current node if the current segment lies inside the update range.

                    3. Recurse for the children as you would normally to find appropriate segments to update.
            
            
            */

            // (high - low + 1) is the number of child nodes under the  current node(is responsible for)
            // call this method as UpdateLazySegmentTree(0, 0, n-1, i, j, val);
            // Here you want to update the range [i, j] with value val.

            public void UpdateLazySegmentTree(int treeIndex, int low, int high, int rangeStart, int rangeEnd, int value){

                if(lazy[treeIndex] != 0){  //this node is lazy

                 //since high - low + 1 is number of child nodes under the current node
                 //and the merge function is a sum, we need to multiply lazy value by this factor
                 //for the overall changes on the parent node
                 //for other merge function like min/max this factor may not be needed

                 tree[treeIndex] += (high - low + 1) * lazy[treeIndex]; //normalize the node by removing laziness

                 //propagate laziness to the child nodes

                 if(low != high){
                     lazy[2*treeIndex + 1] += lazy[treeIndex];
                      lazy[2*treeIndex + 2] += lazy[treeIndex];
                 }

                 lazy[treeIndex] = 0;  //current node processes; no longer lazy

                }


                 //scenario 1; segment outside range

                if(low > high || rangeStart > high || rangeEnd < low ){
                    return;    
                }

                 //scenario 2; segment completely inside range
                 
                if(low >= rangeStart && high <= rangeEnd){
                    tree[treeIndex] += (high - low + 1) * value;  //update parent node

                         // update lazy[] for children                    
                        if(low != high){
                            lazy[2*treeIndex + 1] += value;
                            lazy[2*treeIndex + 2] += value;
                        }

                        return;
                      
                     
                 }

                 
                //scenario 3; partial overlap; Recurse deeper

                int mid = low + (high-low) / 2;

                UpdateLazySegmentTree(treeIndex, low, mid, rangeStart,rangeEnd, value);  //check other node ranges
                UpdateLazySegmentTree(treeIndex, mid + 1, high, rangeStart,rangeEnd, value);

                //merge updates

                tree[treeIndex]  =  tree[2*treeIndex + 1]   +   tree[2*treeIndex + 2];



            }


            /*
                Querying a lazily propagated tree

                This is a two step process:

                   1. Normalize the current node by removing laziness. This step is the same as the update step.
                   2. Recurse for the children as you would normally to find appropriate segments which fit in queried range.

            
            */


            // call this method as QueryLazySegmentTree(0, 0, n-1, i, j);
            // Here [i,j] is the range/interval you are querying.
            // This method relies on "null" nodes being equivalent to storing zero.
              public int QueryLazySegmentTree(int treeIndex, int low, int high, int rangeStart, int rangeEnd){
                

                //scenario 1; segment outside range
                  if(rangeStart > high || rangeEnd < low){
                      return 0;
                  }

                  if(lazy[treeIndex] != 0){

                      tree[treeIndex] += (high - low + 1) * lazy[treeIndex];
                      if(low != high){
                          lazy[2 * treeIndex + 1] = lazy[treeIndex];
                          lazy[2 * treeIndex + 2] = lazy[treeIndex];
                      }

                      lazy[treeIndex] = 0;
                  }

                  //scenario 2; segment completely inside range

                    if( low >= rangeStart && high <= rangeEnd){
                        return tree[treeIndex];
                    }

                    //scenario 3; partial overlap; Recurse deeper

                    int mid = low + (high - low) / 2;

                    if(rangeStart > mid){
                        return QueryLazySegmentTree(2*treeIndex + 2, mid +1, high,rangeStart,rangeEnd);
                    }else if(rangeEnd <= mid){
                         return QueryLazySegmentTree(2*treeIndex + 1, low, mid,rangeStart,rangeEnd);
                    }

                    int leftQuery = QueryLazySegmentTree(2 * treeIndex + 1, low, mid, rangeStart,mid);
                    int rightQuery = QueryLazySegmentTree(2 * treeIndex + 2, mid + 1, high, mid + 1 , rangeEnd);

                    //merge query result

                    return leftQuery + rightQuery;

              }

            #endregion

    }

}