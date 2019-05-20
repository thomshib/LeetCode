using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.LinkedLists;

namespace LeetCodeTest.LinkedLists
{
    [TestClass]
   public class LinkedListTests
    {
        [TestMethod]
        public void AddTwoNumbersResultsInSuccess()
        {
            ListNode L1 = new ListNode(2);
            L1.next = new ListNode(4);
            L1.next.next = new ListNode(3);

            ListNode L2 = new ListNode(5);
            L2.next = new ListNode(6);
            L2.next.next = new ListNode(4);

            var expectedResult = new ListNode(7);
            expectedResult.next = new ListNode(0);
            expectedResult.next.next = new ListNode(8);


            var result = new AddTwoNumbers().AddTwoNumbersSolution(L1, L2);

            Assert.IsTrue(EnumerateLinkedLists(result.next, expectedResult));


        }




        [TestMethod]
        public void MergeTwoSortedListsResultsInSuccess()
        {
            ListNode L1 = new ListNode(1);
            L1.next = new ListNode(2);
            L1.next.next = new ListNode(4);

            ListNode L2 = new ListNode(1);
            L2.next = new ListNode(3);
            L2.next.next = new ListNode(4);


            var expectedResult = new ListNode(1);
            var prev = expectedResult;

            var node = new ListNode(1);
            prev.next = node;
            prev = node;

            node = new ListNode(2);
            prev.next = node;
            prev = node;

            node = new ListNode(3);
            prev.next = node;
            prev = node;

            node = new ListNode(4);
            prev.next = node;
            prev = node;

            node = new ListNode(4);
            prev.next = node;
            prev = node;

            


            var result = new MergeTwoSortedLists().MergeTwoLists(L1, L2);

            Assert.IsTrue(EnumerateLinkedLists(result.next, expectedResult));


        }


        [TestMethod]
        public void CopyListWithRandonPointerResultsInSuccess()
        {
            Node L2 = new Node();
            L2.val = 2;
            L2.next = null;
            L2.random = L2;

            Node L1 = new Node();
            L1.val = 1;
            L1.next = L2;
            L1.random = L2;
            

            

            var result = new CopyListWithRandomPointer().CopyRandomList(L1);

            Assert.IsTrue(EnumerateLinkedLists(result, L1));


        }




        [TestMethod]
        public void ReorderListResultsInSuccess()
        {
            //1>2>3>4>5  => 1>5>2>4>3

            ListNode L1 = new ListNode(1);
            ListNode L2 = new ListNode(2);
            ListNode L3 = new ListNode(3);
            ListNode L4 = new ListNode(4);
            ListNode L5 = new ListNode(5);

            L1.next = L2;
            L2.next = L3;
            L3.next = L4;
            L4.next = L5;
            L5.next = null;

            ListNode eL1 = new ListNode(1);
            ListNode eL2 = new ListNode(2);
            ListNode eL3 = new ListNode(3);
            ListNode eL4 = new ListNode(4);
            ListNode eL5 = new ListNode(5);

            eL1.next = eL5;
            eL5.next = eL2;
            eL2.next = eL4;
            eL4.next = eL3;
            eL3.next = null;
            
            

            new ReorderList().ReorderListSolution(L1);

            Assert.IsTrue(EnumerateLinkedLists(L1,eL1));


        }



        private bool EnumerateLinkedLists(ListNode n1, ListNode n2)
        {
            if (n1 == null)
            {
                return false;
            }
            if (n2 == null)
            {
                return false;
            }

            ListNode L1 = n1;
            

            while(n1 != null)
            {
                if(n1.val != n2.val)
                {
                    return false;
                }
                n1 = n1.next;
                n2 = n2.next;

            }

            return true;
        }


        private bool EnumerateLinkedLists(Node n1, Node n2)
        {
            if (n1 == null)
            {
                return false;
            }
            if (n2 == null)
            {
                return false;
            }

            Node L1 = n1;


            while (n1 != null)
            {
                if (n1.val != n2.val)
                {
                    return false;
                }
                n1 = n1.next;
                n2 = n2.next;

            }

            return true;
        }
    }
}
