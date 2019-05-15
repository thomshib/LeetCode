using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.BackTracking;

namespace LeetCodeTest.BackTracking
{
    [TestClass]
    public class PermutationsTests
    {

        [TestMethod]
        public void PermuteResultsInSucess()
        {
            int[] nums = new int[] { 1, 2, 3 };

            var expectedResult = new List<IList<int>>()
            {
                
                new List<int>(){1,2,3},
                 new List<int>(){1,3,2},
                  new List<int>(){2,1,3},
                   new List<int>(){2,3,1},
                    new List<int>(){3,1,2},
                     new List<int>(){3,2,1}
                        

            };


            var result = new Permutations().Permute(nums);

            var areEqual = CollectionsAreEqual.AreEqualListOfLists<int>(result, (IList<IList<int>>)expectedResult);
            Assert.IsTrue(areEqual);



        }



        [TestMethod]
        public void PermuteWithSwapResultsInSucess()
        {
            int[] nums = new int[] { 1, 2, 3 };

            var expectedResult = new List<IList<int>>()
            {

                new List<int>(){1,2,3},
                 new List<int>(){1,3,2},
                  new List<int>(){2,1,3},
                   new List<int>(){2,3,1},
                    new List<int>(){3,1,2},
                     new List<int>(){3,2,1}


            };


            var result = new Permutations().PermuteWithSwap(nums);

            var areEqual = CollectionsAreEqual.AreEqualListOfLists<int>(result, (IList<IList<int>>)expectedResult);
            Assert.IsTrue(areEqual);



        }




        [TestMethod]
        public void PermutationsWithDuplicatesResultsInSucess()
        {
            int[] nums = new int[] { 1, 1, 2 };

            var expectedResult = new List<IList<int>>()
            {

                new List<int>(){1,1,2},
                 new List<int>(){1,2,1},
                  new List<int>(){2,1,1}


            };


            var result = new PermutationsWithDuplicates().PermuteUnique(nums);

            var areEqual = CollectionsAreEqual.AreEqualListOfLists<int>(result, (IList<IList<int>>)expectedResult);
            Assert.IsTrue(areEqual);



        }

    }
}
