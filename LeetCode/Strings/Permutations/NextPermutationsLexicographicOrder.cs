using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings.Permutation
{


//Find all permutations of a string

/*
    //Approach using lexigographic order
    https://www.cut-the-knot.org/do_you_know/AllPerm.shtml#Dijkstra

    Permutation f precedes a permutation g in the lexicographic (alphabetic) order 
    iff for the minimum value of k such that f(k)≠ g(k), we have f(k) < g(k). 

        *Find next permutation as per Lexicogrpahic Order
            1. Find the largest i such that P[i] < P[i+1] ; If there is no such i, P is the last permutation
            2. Find the largest j such that P[i] < P[j]
            3. Swap P[i] and P[j]
            4. Reverse P[i+1....n] 

*/
public class NextPermutationsLexicographicOrder{

    public string NextLexicographicPermutation(string input){

        var charSet = input.ToCharArray();
        int N = charSet.Length;

        //Step 1
        int largestI = -1;
        for(int i = 0 ; i < N-1; i++){
            if(charSet[i] < charSet[i+1]){
                largestI = i;
            }
        }

        //if not found return
        if(largestI == -1) return input;


        //Step 2
         int largestJ = -1;
        for(int j = 0 ; j < N; j++){
            if(charSet[j] < charSet[largestI]){
                largestJ = j;
            }
        }

        //Step 3
        Swap(charSet,largestI,largestJ);

        //Step 4
        // Reverse from largestI to end
        Reverse(charSet,largestI, N);

        return charSet.ToString();

    }



public string NextLexicographicPermutationUsingWhileLoop(string input){
    
    var charSet = input.ToCharArray();
    int N = charSet.Length;
    // Find the longest non increasing suffix
    int i = N;

    while(i>0 && charSet[i-1] >= charSet[i]){
        i--;
    }

    //Now i is the head index of the suffix

    //Are we at the last permutation already
    if(i <=0 ){
        return input;
    }

    //Let charSet[i-1] be the pivot
    //Find rightmost element that exceeds the pivot
    int j = N;

    while(charSet[j] <= charSet[i]){
        j--;
    }

    //Now the charSet[j] will become the new pivot
    //assertion: j >= i

    // swap the pivot with j
    Swap(charSet, i-1,j);

    // Reverse the suffix
    j = N-1;
    Reverse(charSet,i,j);

    return charSet.ToString();

}
      private  void Swap( char[] value,int i, int j)
        {
            var temp = value[i];
            value[i] = value[j];
            value[j] = temp;
        }

        private void Reverse(char[] nums, int startIndex, int endIndex)
        {
            while(startIndex < endIndex)
            {
                Swap(nums, startIndex++, endIndex--);
            }
        }

}

}