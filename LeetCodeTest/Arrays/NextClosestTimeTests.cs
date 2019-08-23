using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Arrays;
using LeetCodeTest.Utility;



namespace LeetCodeTest.Arrays
{
     [TestClass]
    public class NextClosestTimeTests
    {
        [TestMethod]
        public void ClosestTime_Success(){
            string time = "19:34";
            var expectedResult = "19:39";
            var result = new NextClosestTime().NextClosestTimeSolution(time);

            Assert.AreEqual(result, expectedResult);
        }
    }
}