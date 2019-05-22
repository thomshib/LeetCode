using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.SortingAndSearching;
using LeetCodeTest.Utility;

namespace LeetCodeTest.SortingAndSearching
{

    [TestClass]
    public class SortingAndSearchingTests
    {
        [TestMethod]
        public void DivideTwoIntegersSuccess()
        {

            int divident = 15;
            int divisor = 3;

            var result = new DivideTwoIntegers().Divide(divident, divisor);

            Assert.AreEqual(result, 5);

        }


        [TestMethod]
        public void SearchRotatedSortedArraySuccess()
        {

            int[] input = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            int target = 0;

            var result = new SearchRotatedSortedArray().Search(input,target);

            Assert.AreEqual(result, 4);

        }

        

             [TestMethod]
        public void FindFirstandLastPositionSuccess()
        {

            int[] input = new int[] { 5, 7, 7, 8, 8, 10 };
            int target = 8;

            var result = new FindFirstandLastPosition().SearchRange(input, target);

            Assert.AreEqual(result, 4);

        }


        [TestMethod]
        public void PowerSuccess()
        {


            double precision = 1e-6;

            var result = new Power().Pow(2.0, 10);

            Assert.AreEqual(result, 1024.00);


            result = new Power().Pow(2.10, 3);

            Assert.AreEqual(result, 9.26100,precision);


            result = new Power().Pow(2.0, -2);

            Assert.AreEqual(result, 0.2500,precision);

        }


        [TestMethod]
        public void MergeIntervalsSuccess()
        {

            int[][] input = new int[][]
            {
                new int[]{ 1,3},
                 new int[]{ 2,6},
                  new int[]{ 8,10},
                   new int[]{ 15,18}

            };

            int[][] expectedResult = new int[][]
            {
                new int[]{ 1,6},
                 new int[]{ 8,10},                  
                   new int[]{ 15,18}

            };

            

            var result = new MergeIntervals().Merge(input);

            var isEqual = ArrayEquivalence.sequencesEqual(result, expectedResult);


            Assert.IsTrue(isEqual);

        }


        [TestMethod]
        public void PeakElementSuccess()
        {


           

            int[] input = new int[] { 1, 2, 3, 1 };

            var result = new PeakElement().FindPeakElement(input);

            Assert.AreEqual(result, 2);


            input = new int[] { 1, 2, 1,3, 5,6,4 };

            result = new PeakElement().FindPeakElement(input);


            
            Assert.IsTrue(result == 5 ||  result == 1);


        }

        [TestMethod]
        public void IntersectionOfTwoArraysSuccess()
        {




            int[] input1 = new int[] { 1, 2, 2, 1 };
            int[] input2 = new int[] { 2, 2 };

            var expectedResult = new int[] { 2 };

            var result = new IntersectionofTwoArrays().Intersection(input1, input2);


            var isequal = ArrayEquivalence.sequencesEqual(result, expectedResult);
            Assert.IsTrue(isequal);


            input1 = new int[] {4,9,5 };
            input2 = new int[] { 9, 4, 9, 8, 4 };
            expectedResult = new int[] { 9, 4 };

             result = new IntersectionofTwoArrays().Intersection(input1, input2);


             isequal = ArrayEquivalence.sequencesEqual(result, expectedResult);
            Assert.IsTrue(isequal);


        }
    }
}
