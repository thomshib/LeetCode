using System;
using System.Collections.Generic;
using System.Text;
namespace LeetCode.DataStructures{
    

    //https://www.youtube.com/watch?v=v_wj_mOAlig

    /*
        Properties:

            //how to get the rightmost significant digit : x & (-x)
                1. Remove last bit set : x - (x & (-x))
                2. Add last bit set : x + (x & (-x))


            Navigation choices
                1. Move to a parent node- remove the rightmost significant digit of the node = x - (x & (-x))
                2. Move to a child node- add the rightmost significant digit of the node = x + (x & (-x))

    
    
    
    */

    

    public class BinaryIndexedTree
    {

        int[] tree;
        int treeLength;

        public BinaryIndexedTree(int[] input)
        {
             int treeLength = input.Length;
            tree = new int[treeLength + 1 ]; //0 index is not used

            for(int index = 0; index < treeLength ; index++){
                tree[index + 1] = input[index];
            }

            //update child with values of the parent

             for(int parentIndex = 0; parentIndex < treeLength ; parentIndex++){
                int childIndex = parentIndex + (parentIndex & (-parentIndex));

                if( childIndex < treeLength){
                    tree[childIndex] += tree[parentIndex];
                }

            }
        }
       

        public int Query(int index){
            int result = 0;
            index++; // since the tree is 1 indexed
            while(index > 0){
                result += tree[index];
                //move up to the parent
                index = index - (index & (-index));
            }

            return result;
        }


        // Computes the range sum between two indices (both inclusive)    
        public int RangeQuery(int rangeStart, int rangeEnd){
                //ranges are not incremented since the Query function will increment these
                if(rangeStart == 0){
                    return Query(rangeEnd);
                }else{
                    return Query(rangeEnd) - Query(rangeStart);
                }
        }

        public void Update(int index, int value){
            index++; //since the tree is one indexed
            while(index < treeLength + 1){
                tree[index + 1] = value;
                index = index + (index & (-index));

            }

        }



    }

}