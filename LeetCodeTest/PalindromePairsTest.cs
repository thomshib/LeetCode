using LeetCode.PlaindromePairs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest
{
    [TestClass]
    public class PalindromePairsTest
    {


        [TestMethod]
        public void BruteForce_Success()
        {
            var expectedResult = new List<List<int>>()
            {
                new List<int>(){0,1},
                new List<int>(){1,0}
            };

            List<string> words = new List<string>() { "bat", "tab", "cat"};
            var result = new PalindromePair().BruteForceSolution(words);

            var areEqual = CollectionsAreEqual.AreEqualListOfLists(result, expectedResult);
            Assert.IsTrue(areEqual);
        }


        [TestMethod]
        public void Trie_WordsofEqualLength_Success()
        {
            var expectedResult = new List<Tuple<int,int>>()
            {
                new Tuple<int,int>(0,1),
                new Tuple<int,int>(1,0)
            };

            List<string> words = new List<string>() { "bat", "tab", "cat" };
            var result = new PalindromePair().PalindromePairsSolution(words.ToArray());

            var areEqual = CollectionsAreEqual.AreEqualListOfTuple(result, expectedResult);
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void Trie_WordsShorterThan_Success()
        {
            var expectedResult = new List<Tuple<int, int>>()
            {
                new Tuple<int,int>(0,2)
                
            };

            List<string> words = new List<string>() { "acbe", "ca", "bca" };
            var result = new PalindromePair().PalindromePairsSolution(words.ToArray());

            var areEqual = CollectionsAreEqual.AreEqualListOfTuple(result, expectedResult);
            Assert.IsTrue(areEqual);
        }


        [TestMethod]
        public void Trie_WordsLongerThan_Success()
        {
            var expectedResult = new List<Tuple<int, int>>()
            {
                new Tuple<int,int>(0,1)

            };

            List<string> words = new List<string>() { "ca", "bac" };
            var result = new PalindromePair().PalindromePairsSolution(words.ToArray());

            var areEqual = CollectionsAreEqual.AreEqualListOfTuple(result, expectedResult);
            Assert.IsTrue(areEqual);
        }


    }

  
}

