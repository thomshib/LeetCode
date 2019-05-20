using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.LinkedLists
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node() { }
        public Node(int _val, Node _next, Node _random)
        {
            val = _val;
            next = _next;
            random = _random;
        }
    }

    //https://leetcode.com/explore/interview/card/facebook/6/linked-list/3020
    //https://leetcode.com/explore/interview/card/facebook/6/linked-list/3020/discuss/43491/A-solution-with-constant-space-complexity-O(1)-and-linear-time-complexity-O(N)

    public class CopyListWithRandomPointer
     {
        /*
         * 
         * 1- Iterate the original list and duplicate each node. The duplicate
            of each node follows its original immediately.

            2- Iterate the new list and assign the random pointer for each
            duplicated node.

            3-Restore the original list and extract the duplicated nodes.
         * 
         * 
         * 
         * 
         */
        public Node CopyRandomList(Node head)
        {

            Node iter = head;
            Node next;
            Node copy;

            //1- create a copy
            while (iter != null)
            {
                next = iter.next;

                copy = new Node(iter.val, next, iter.random);

                iter.next = copy;

                copy.next = next;

                iter = next;
            }

            //2- Assign the random pointer

            iter = head;
            while(iter != null)
            {
                if(iter.random != null)
                {
                    //iter.next is nothing but copied node
                    //iter.randon will also point to copied node

                    iter.next.random = iter.random.next;
                }

                iter = iter.next.next;
            }

            //restore the original list and extract the copy list

            iter = head;
            Node copyHead = new Node();
            copyHead.val = -1;

           
            Node copyIter;
            copyIter = copyHead;

            while(iter != null){

                next = iter.next.next;

                //extract the copy
                copy = iter.next;
                copyIter.next = copy;
                copyIter = copy;

                //restore the original list

                iter.next = next;
                iter = next;
            }

            return copyHead.next;
        }
    }
}
