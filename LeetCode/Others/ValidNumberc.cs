using System;


namespace LeetCode.Others
{

    //https://leetcode.com/problems/valid-number/
public class ValidNumber{

 public bool IsNumber(string s) {
        
      if(s == null || s.Trim().Length == 0) return false;

      bool seenNumber = false;
      bool seenExponent = false;
      bool seenDot = false;

      s = s.Trim();

      for(int i = 0; i < s.Length; i++){
        char character = s[i];

        switch(character){
            case '.':
                if(seenDot || seenExponent){
                    return false;
                }
                seenDot = true;
                break;


            case 'e':
                if(seenExponent || !seenNumber){
                    return false;
                }
                seenExponent = true;
                seenNumber = false;
                break;

            case '+':
            case '-':
                // check previous character
                if(i != 0 &&  s[i-1] != 'e'){
                    return false;
                    }
                    seenNumber = false;
                    break;

             default:
                if(character -'0' < 0 || character -'0' > 9){
                    return false;
                }
                seenNumber = true;
                break;


        }
      }

    
        return seenNumber;
    }


}

}