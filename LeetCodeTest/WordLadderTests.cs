using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LeetCode.WordLadders;
using System.Linq;

namespace LeetCodeTest
{
    [TestClass]
    public class WordLadderTests
    {
        [TestMethod]
        public void HasPathToEndWord_Pass()
        {
            string beginWord = "hit";
            string endWord = "cog";
            List<string> wordDic = new List<string>() { "hot", "dot", "dog", "lot", "log","cog" };

            WordLadder client = new WordLadder();
            var result = client.LadderShotestLenght(beginWord, endWord, wordDic);

            Assert.IsTrue(result > 0);

        }


        [TestMethod]
        public void HasNoPathToEndWord_Pass()
        {
            string beginWord = "hit";
            string endWord = "cog";
            List<string> wordDic = new List<string>() { "hot", "dot", "dog", "lot", "log" };

            WordLadder client = new WordLadder();
            var result = client.LadderShotestLenght(beginWord, endWord, wordDic);

            Assert.IsTrue(result == 0);

        }

        [TestMethod]
        public void AllShortestLadders_Success()
        {
            var expectedResult = new List<List<string>>()
            {
                new List<string>(){ "hit","lit","lot","log","cog"},
                new List<string>(){"hit","hot","dot","dog","cog" },
                new List<string>(){ "hit","hot","lot","log","cog"}
                
            };
            string beginWord = "hit";
            string endWord = "cog";
            List<string> wordList = new List<string>() {"hot","lit","dot","dog","lot","log","cog"};
             WordLadder client = new WordLadder();
            var result = client.AllShortestLadders(beginWord, endWord, wordList);

            var areEqual = AreEqualListOfLists<string>(result, expectedResult);
            Assert.IsTrue(areEqual);

            

        }


        [TestMethod]
        public void AllShortestLadders_Optimized_Success()
        {
            var expectedResult = new List<List<string>>()
            {
                new List<string>(){ "hit","lit","lot","log","cog"},
                new List<string>(){"hit","hot","dot","dog","cog" },
                new List<string>(){ "hit","hot","lot","log","cog"}

            };
            string beginWord = "hit";
            string endWord = "cog";
            List<string> wordList = new List<string>() { "hot", "lit", "dot", "dog", "lot", "log", "cog" };
            WordLadder client = new WordLadder();
            var result = client.AllShortestLadders_Optimized(beginWord, endWord, wordList);

            var areEqual = AreEqualListOfLists<string>(result, expectedResult);
            Assert.IsTrue(areEqual);



        }

        [TestMethod]
        public void AllShortestLadders_Using_CustomClass_Success()
        {
            var expectedResult = new List<List<string>>()
            {
                new List<string>(){ "hit","lit","lot","log","cog"},
                new List<string>(){"hit","hot","dot","dog","cog" }
                

            };
            string beginWord = "hit";
            string endWord = "cog";
            List<string> wordList = new List<string>() { "hot", "lit", "dot", "dog", "lot", "log", "cog" };
            WordLadder client = new WordLadder();
            var result = client.AllShortestLadders_Optimized_Using_CustomClass(beginWord, endWord, wordList);

            var areEqual = AreEqualListOfLists<string>(result, expectedResult);
            Assert.IsTrue(areEqual);



        }


        public static bool AreEqual<T>(IList<T> list1, IList<T> list2)
        {
            if(list1?.Count != list2?.Count)
            {
                return false;
            }

            return list1.SequenceEqual(list2);
        }

        public static bool AreEqualListOfLists<T>(IList<List<T>> lists1, IList<List<T>> lists2)
        {
            return lists1.All(innerList1 => lists2.Any(innerList2 => AreEqual(innerList1, innerList2)));

        }
    }
}
