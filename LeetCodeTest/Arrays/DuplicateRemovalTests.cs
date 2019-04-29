using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Arrays;
using LeetCodeTest.Utility;

namespace LeetCodeTest.Arrays
{
    [TestClass]
    public class DuplicateRemovalTests
    {
        [TestMethod]
        public void DuplicateRemovalResultsinSuccess()
        {
            var input = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            var expectedResult = 5;

            var result = new DuplicateRemoval().RemoveDuplicates(input);



            Assert.AreEqual(result, expectedResult);
        }
    }
}
