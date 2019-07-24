using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.DataStructures;

namespace LeetCodeTest.DataStructures
{

[TestClass]
    public class LRUCacheTests
    {

        [TestMethod]
        public void LRUCacheSuccess(){

            LRUCache cache = new LRUCache(2); /* capacity */
            int result = 0;
            cache.Put(1, 1);
            cache.Put(2, 2);
            result = cache.Get(1);       // returns 1
            Assert.AreEqual(result,1);


            cache.Put(3, 3);    // evicts key 2; returns -1 (not found)
            result = cache.Get(2);
            Assert.AreEqual(result,-1);
            
            
            cache.Put(4, 4);    // evicts key 1
            result = cache.Get(1);       // returns -1 (not found)
            Assert.AreEqual(result,-1);


            result = cache.Get(3);       // returns 3
             Assert.AreEqual(result,3);

            result = cache.Get(4);       // returns 4
             Assert.AreEqual(result,4);
        }

    }
}