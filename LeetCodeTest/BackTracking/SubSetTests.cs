using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.BackTracking;

namespace LeetCodeTest.BackTracking
{
    [TestClass]
    public class SubSetTests
    {

        [TestMethod]
        public void SubsSetTestsResultsInSucess()
        {
            int[] nums = new int[] { 1, 2, 3 };

            var expectedResult = new List<IList<int>>()
            {
                new List<int>(),
                new List<int>(){1},
                 new List<int>(){2},
                  new List<int>(){3},
                   new List<int>(){1,2},
                    new List<int>(){1,3},
                     new List<int>(){2,3},
                         new List<int>(){1,2,3}

            };


            var result =  new SubSet().Subsets(nums);

            var areEqual = CollectionsAreEqual.AreEqualListOfLists<int>(result, (IList<IList<int>>) expectedResult);
            Assert.IsTrue(areEqual);



        }

        [TestMethod]
        public void SubsSetsWithDuplicateResultsInSucess()
        {
            int[] nums = new int[] { 1, 2, 2 };

            var expectedResult = new List<IList<int>>()
            {
                new List<int>(),
                new List<int>(){1},
                 new List<int>(){2},
                  new List<int>(){2,2},
                   new List<int>(){1,2},                    
                         new List<int>(){1,2,2}

            };


            var result = new SubSet().SubsetsWithDup(nums);

            var areEqual = CollectionsAreEqual.AreEqualListOfLists<int>(result, (IList<IList<int>>)expectedResult);
            Assert.IsTrue(areEqual);



        }
    }
}
