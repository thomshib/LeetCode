using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.LinkedLists
{
    public class ReorderList
    {
        //https://leetcode.com/explore/interview/card/facebook/6/linked-list/3021/
        //https://leetcode.com/explore/interview/card/facebook/6/linked-list/3021/discuss/44992/Java-solution-with-3-steps


        public void ReorderListSolution(ListNode head)
        {

            if (head == null) return;

            ListNode left = head;
            ListNode right = head;

            //find the middle 
            while (right.next != null && right.next.next != null)
            {
                left = left.next;
                right = right.next.next;
            }


            //reverse the right part of the list
            // 1 > 2 >3 > 4 > 5 > 6  => 1 > 2 > 3 > 6 > 5 > 4

            ListNode leftTail = left;
            ListNode rightHead = left.next;
            ListNode newRightHead = null;

            while(rightHead != null)
            {
                ListNode nextNode = rightHead.next;
                rightHead.next = newRightHead;
                newRightHead = rightHead;
                rightHead = nextNode;
            }

            //merge two parts of the list one by one
            // 1>2>3 & 6>5>4  =>  1>6>2>5>3>4

            ListNode currLeft = head;
            ListNode currRight = newRightHead;

            while(currLeft != leftTail)
            {
                ListNode nextLeft = currLeft.next;

                ListNode nextRight = currRight.next;

                currLeft.next = currRight; //1>6

                currRight.next = nextLeft; //6>2

                currLeft = nextLeft;
                currRight = nextRight;
            }

            //if the size is odd, we set the right tail to null to avoid cycle

            if(currRight == null)
            {
                currLeft.next = null;
            }

        }
    }
}
