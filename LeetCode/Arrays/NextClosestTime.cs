using System;
using System.Collections.Generic;


namespace LeetCode.Arrays
{
    public class NextClosestTime
    {
        //https://leetcode.com/explore/interview/card/google/59/array-and-strings/3055

        /*
            Approach
          Simulate the clock going forward by one minute. Each time it moves forward, if all the digits are allowed, then return the current time.

            The natural way to represent the time is as an integer t in the range 0 <= t < 24 * 60. 
            Then the hours are t / 60, the minutes are t % 60, 
            and each digit of the hours and minutes can be found by hours / 10, hours % 10 etc.
            Time Complexity: O(1). We try up to 24 * 6024∗60 possible times until we find the correct time.

            Space Complexity: O(1).
        */
        public string NextClosestTimeSolution(string time) {

            /* 
                hh = ticks / 60
                mm = ticks % 60

                19 = 1 * 10 + 9 => 19 / 10 + 19 % 10


            */
            // 
            
            //convert to minutes
            int ticks = 60 * Convert.ToInt16(time.Substring(0,2));
            ticks +=  Convert.ToInt16(time.Substring(3));

            HashSet<int> allowedNumbers = new HashSet<int>();
            var charSet = time.ToCharArray();

            for(int i = 0; i < charSet.Length ;i++){
                if(charSet[i] != ':'){
                allowedNumbers.Add(charSet[i] - '0');
                }
            }

            bool isValid;
            while(true){
                isValid = true;
                ticks = (ticks + 1) % (24 * 60);  //convert to minutes
                int[] digits = new int[]{ (ticks / 60) / 10, (ticks / 60) % 10 , (ticks % 60) / 10 , (ticks % 60) % 10};
                
                for(int i = 0; i < digits.Length; i++){
                    if(!allowedNumbers.Contains(digits[i])){
                        isValid = false;
                        break;
                    }
                }
                if(isValid == true){
                     return String.Format("{0}:{1}", ticks / 60, ticks % 60);
                }
                
            }   
        }

        //Approach 2 Build from allowed digits
            /*
            We have up to 4 different allowed digits, which naively gives us 4 * 4 * 4 * 4 possible times. 
            For each possible time, let's check that it can be displayed on a clock: ie., hours < 24 and mins < 60. 
            The best possible time != start is the one with the smallest cand_elapsed = (time - start) % (24 * 60), 
            as this represents the time that has elapsed since start, and where the modulo operation is taken to be always non-negative.

            For example, if we have start = 720 (ie. noon), then times like 12:05 = 725 means that (725 - 720) % (24 * 60) = 5 seconds 
            have elapsed; while times like 00:10 = 10 means that (10 - 720) % (24 * 60) = -710 % (24 * 60) = 730 seconds have elapsed.

            Also, we should make sure to handle cand_elapsed carefully. When our current candidate time cur is equal to the 
            given starting time, then cand_elapsed will be 0 and we should handle this case appropriately.
            
            
            */

          

    }
}