using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.LinkedLists
{
    //https://leetcode.com/explore/interview/card/facebook/6/linked-list/301/
    public class MergeTwoSortedLists
    { 
     public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
            if (l1 == null || l2 == null)
            {
                return l1 == null ? l2 : l1;
            }

            ListNode head = new ListNode(-1);
            ListNode prev = head;

            int l1Value;
            int l2Value;
            while(l1 != null || l2 != null)
            {
                ListNode node;

                l1Value = int.MaxValue;
                l2Value = int.MaxValue;

                if(l1 != null)
                {
                    l1Value = l1.val;

                }

                if(l2 != null)
                {
                    l2Value = l2.val;
                }

                if(l1Value <= l2Value)
                {
                    node = new ListNode(l1Value);
                    l1 = l1 == null ? l1 : l1.next;
                }
                else
                {
                    node = new ListNode(l2Value);
                    l2 = l2 == null ? l2 : l2.next;
                }

                prev.next = node;
                prev = node;
            }


            return head;

    }

}
}
