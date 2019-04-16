using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Streams;

namespace LeetCodeTest.Streams
{

    [TestClass]
    public class MedianOfStreamTests
    {

        [TestMethod]
        public void MedianOfStream_WhenInputIsOdd_Success()
        {
            var expectedResult = 3;
            var list = new double[] { 2, 3, 4 };
            var result = new MedianOfStream().FindMedian(list);

            Assert.AreEqual(result, expectedResult);

        }

        [TestMethod]
        public void MedianOfStream_WhenInputIsEven_Success()
        {
            var expectedResult = 2.5;
            var list = new double[] { 2, 3 };
            var result = new MedianOfStream().FindMedian(list);

            Assert.AreEqual(result, expectedResult);

        }
    }
}
