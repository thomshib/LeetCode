using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeTest.Misc
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void AllSubsetsOfaSet_Success()
        {
            var input = new int[] { 1,2};
            var test = new AllSubsetsOfaSet();
            test.AllSubsets(input);
        }
    }
}
