using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.LinkedLists
{
    //https://leetcode.com/explore/interview/card/facebook/6/linked-list/319/

    public class ListNode
    {
    public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
    public class AddTwoNumbers
    {
        public ListNode AddTwoNumbersSolution(ListNode l1, ListNode l2)
        {

            if(l1 == null || l2 == null)
            {
                return l1 == null ? l2 : l1;
            }
            
            
            
            ListNode head = new ListNode(-1);
            ListNode prev = head;
            int sum = 0;
            

            while (l1 != null || l2 != null || sum!=0)
            {
                sum += l1 == null ? 0: l1.val;
                sum += l2 == null ? 0 : l2.val;

                l1 = l1 == null ? l1 : l1.next;
                l2 = l2 == null ? l2 : l2.next;

                
                ListNode node = new ListNode(sum % 10);
                prev.next = node;
                prev = node;

                sum = sum / 10;
                
                
               
                
            }

            return head;
        }

        public ListNode AddTwoNumbersAlternative(ListNode l1, ListNode l2)
        {

            ListNode result = null;
            ListNode head = null;

            if (l1 == null && l2 == null)
            {
                return result;
            }
            else if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }

            int remainder = 0;

            while (l1 != null || l2 != null)
            {

                int sum = 0;


                sum = l1 == null ? sum : sum + l1.val;

                sum = l2 == null ? sum : sum + l2.val;

                sum += remainder;

                remainder = sum / 10;

                sum = sum % 10;

                if (result == null)
                {
                    result = new ListNode(sum);

                }
                else
                {
                    result.next = new ListNode(sum);
                    result = result.next;
                }

                l1 = l1.next;
                l2 = l2.next;

            }

            return result;
        }
    }
}
