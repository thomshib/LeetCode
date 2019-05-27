using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Graphs;

namespace LeetCodeTest.Graphs
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void AlienDictionarySuccess()
        {
            string[] input = new string[]
            {
                  "wrt",
                  "wrf",
                  "er",
                  "ett",
                  "rftt"
            };

            var expectedResult = "wertf";

            var result = new AlienDictionary().AlienOrder(input);

            Assert.AreEqual(result, expectedResult);


            input = new string[]  { "za", "zb", "ca", "cb"};

            expectedResult = "zacb";

            result = new AlienDictionary().AlienOrder(input);

            Assert.AreEqual(result, expectedResult);


            input = new string[] { "z", "x", "z" };

            expectedResult = "";

            result = new AlienDictionary().AlienOrder(input);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]

        public void ShortestDistancefromAllBuildingsSuccess()
        {
            int[][] input = new int[][]{
                new int[] {1,0,2,0,1 },
                new int[] {0,0,0,0,0 },
                new int[] {0,0,1,0,0 }

            };

            var result = new ShortestDistancefromAllBuildings().ShortestDistance(input);
            Assert.AreEqual(result, 7);
        }


        [TestMethod]
        public void AccountMergeSuccess()
        {
            List<IList<string>> account = new List<IList<string>>();
            account.Add(new List<string>() { "Name1", "a", "b", "" });
        }
    }
}
