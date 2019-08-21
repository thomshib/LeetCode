using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Arrays;
using LeetCodeTest.Utility;

namespace LeetCodeTest.Arrays
{
    [TestClass]
    public class JumpGameTests
    {
        [TestMethod]
        public void BackTrack_Success()
        {
            var input = new int[]{2,3,1,1,4};

            var result = new JumpGame().CanJump(input);
            Assert.IsTrue(result);

            input = new int[]{3,2,1,0,4};
            result = new JumpGame().CanJump(input);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanJumpFromPositionDynamicPrgTopDown_Success()
        {
            var input = new int[]{2,3,1,1,4};

            var result = new JumpGame().CanJump(input);
            Assert.IsTrue(result);

            input = new int[]{3,2,1,0,4};
            result = new JumpGame().CanJump(input);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanJumpFromPositionDynamicPrgBottomDown_Success()
        {
            var input = new int[]{2,3,1,1,4};

            var result = new JumpGame().CanJump(input);
            Assert.IsTrue(result);

            input = new int[]{3,2,1,0,4};
            result = new JumpGame().CanJump(input);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanJumpFromPositionDynamicGreedy_Success()
        {
            var input = new int[]{2,3,1,1,4};

            var result = new JumpGame().CanJump(input);
            Assert.IsTrue(result);

            input = new int[]{3,2,1,0,4};
            result = new JumpGame().CanJump(input);
            Assert.IsFalse(result);
        }
    }

}