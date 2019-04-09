using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Misc
{

    //https://leetcode.com/problems/add-binary/
    public class BinaryAdditionofString
    {

        int sum;
        int carry;
        public BinaryAdditionofString()
        {
            string a = "11";
            string b = "1";

            Console.WriteLine(BinaryAdd(a, b));

            Console.WriteLine();
        }

        public string BinaryAdd(string leftOperand, string rightOperand)
        {
            StringBuilder sb = new StringBuilder();

            int i = leftOperand.Length - 1;
            int j = rightOperand.Length - 1;
            int carry = 0;
            while(i >=0 || j >= 0)
            {
                sum = carry;

                if (i >= 0)
                {
                    sum += Convert.ToInt16(leftOperand[i].ToString());
                    i--;
                }

                if (j >= 0)
                {
                   
                    sum += Convert.ToInt16(rightOperand[j].ToString()); ;
                  
                    j--;
                }
                            

                sb.Insert(0, sum % 2);
                carry = Convert.ToInt16(sum / 2);
            }

            if(carry > 0)
            {
                sb.Insert(0, carry);
            }


            return sb.ToString();
        }

    }
}
