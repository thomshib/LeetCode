using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.BinaryHeaps;

namespace LeetCodeTest.BinaryHeaps
{

    [TestClass]
    public class BinaryHeapTests
    {

        [TestMethod]
        public void BinaryHeapAsMinHeap()
        {
            List<int> list = new List<int>() { 9, 8, 7 };
            var heap = new BinaryHeap<int>(list,false);

            Assert.AreEqual(heap.Peek(), 7);
        }


        [TestMethod]
        public void BinaryHeapAsMaxHeap()
        {
            List<int> list = new List<int>() { 7,8,9 };
            var heap = new BinaryHeap<int>(list,true);

            Assert.AreEqual(heap.Peek(), 9);
        }
    }
}
